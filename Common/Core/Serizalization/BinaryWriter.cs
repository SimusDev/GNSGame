using System;
using System.Linq.Expressions;
using System.Text;

namespace Common.Core.Serizalization;

public unsafe class BinaryWriter : IDisposable
{

    private byte[] _buffer;
    private int _position;
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: освободить управляемое состояние (управляемые объекты)
            }

            // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
            // TODO: установить значение NULL для больших полей
            disposedValue = true;
        }
    }

    // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
    // ~BinaryWriter()
    // {
    //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public BinaryWriter(int initialCapacity = 64)
    {
        _buffer = new byte[initialCapacity];
        _position = 0;
    }

    public BinaryWriter(byte[] externalBuffer)
    {
        _buffer = externalBuffer;
        _position = 0;
    }

    public void WriteBool(bool value)
    {
        EnsureCapacity(1);
        _buffer[_position++] = value ? (byte)1 : (byte)0;
    }

    public void WriteByte(byte value)
    {
        EnsureCapacity(1);
        _buffer[_position++] = value;
    }

    public void WriteSByte(sbyte value)
    {
        EnsureCapacity(1);
        _buffer[_position++] = (byte)value;
    }

    public void WriteUShort(ushort value)
    {
        EnsureCapacity(2);
        fixed (byte* ptr = &_buffer[_position])
            *(ushort*)ptr = value;
        _position += 2;
    }

    public void WriteShort(short value)
    {
        EnsureCapacity(2);
        fixed (byte* ptr = &_buffer[_position])
            *(short*)ptr = value;
        _position += 2;
    }


    public void WriteInt(int value)
    {
        EnsureCapacity(4);
        fixed (byte* ptr = &_buffer[_position])
            *(int*)ptr = value;
        _position += 4;
    }

    public void WriteUInt(uint value)
    {
        EnsureCapacity(4);
        fixed (byte* ptr = &_buffer[_position])
            *(uint*)ptr = value;
        _position += 4;
    }

    public void WriteFloat(float value)
    {
        EnsureCapacity(4);
        fixed (byte* ptr = &_buffer[_position])
            *(float*)ptr = value;
        _position += 4;
    }

    public void WriteDouble(double value)
    {
        EnsureCapacity(8);
        fixed (byte* ptr = &_buffer[_position])
            *(double*)ptr = value;
        _position += 8;
    }

    public void WriteVarInt(int value)
    {
        EnsureCapacity(5);
        while (value > 127)
        {
            _buffer[_position++] = (byte)(value | 0x80);
            value >>= 7;
        }
        _buffer[_position++] = (byte)value;
    }

    public void WriteVarLong(long value)
    {
        EnsureCapacity(10); 
        while (value > 127)
        {
            _buffer[_position++] = (byte)(value | 0x80);
            value >>= 7;
        }
        _buffer[_position++] = (byte)value;
    }
    public void WriteLong(long value)
    {
        EnsureCapacity(8);
        fixed (byte* ptr = &_buffer[_position])
            *(long*)ptr = value;
        _position += 8;
    }
    public void WriteULong(ulong value)
    {
        EnsureCapacity(8);
        fixed (byte* ptr = &_buffer[_position])
            *(ulong*)ptr = value;
        _position += 8;
    }

    public void WriteBytes(ReadOnlySpan<byte> data)
    {
        EnsureCapacity(data.Length);
        data.CopyTo(_buffer.AsSpan(_position));
        _position += data.Length;
    }

    public void WriteBytesDynamic(ReadOnlySpan<byte> data)
    {
        WriteVarInt(data.Length);
        WriteBytes(data);
    }

    public void WriteString(string value)
    {
        if (value == null)
        {
            WriteVarInt(-1);
            return;
        }

        int maxBytes = Encoding.UTF8.GetMaxByteCount(value.Length);
        EnsureCapacity(maxBytes + 5);

        int bytesWritten = Encoding.UTF8.GetBytes(value, _buffer.AsSpan(_position + 5));
        WriteVarInt(bytesWritten);
        _position += bytesWritten;
    }

    private void EnsureCapacity(int needed)
    {
        if (_position + needed <= _buffer.Length) return;

        int newSize = Math.Max(_buffer.Length * 2, _position + needed);
        Array.Resize(ref _buffer, newSize);
    }

    public void SetBuffer(byte[] externalBuffer, bool reset = true)
    {
        _buffer = externalBuffer;
        if (reset)
            Reset();
    }

    public ArraySegment<byte> GetSegment()
    {
        return new ArraySegment<byte>(_buffer, 0, _position);
    }

    public Span<byte> GetSpan()
    {
        return _buffer.AsSpan(0, _position);
    }

    public byte[] ToArray()
    {
        byte[] result = new byte[_position];
        Buffer.BlockCopy(_buffer, 0, result, 0, _position);
        return result;
    }

    public void Reset()
    {
        _position = 0;
    }

    public int Position => _position;
    public int Length => _position;
    public int Available => Length - _position;

    public void WriteSerializable(INetworkSerializable value)
    {
        WriteString(value.GetType().FullName);
        value.NetworkSerialize(this);
    }


}