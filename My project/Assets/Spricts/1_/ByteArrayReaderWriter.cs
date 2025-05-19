using System;
using System.Buffers.Binary;


/// <summary>
/// 高效序列化化和反序列化字节数组工具
/// </summary>
public static class ByteArrayReaderWriter
{
    // ==== Read Methods (Big-Endian) ====
    public static void ReadByte(this byte[] data, ref int offset, out byte value)
    {
        value = data[offset];
        offset += sizeof(byte);
    }

    public static void ReadShort(this byte[] data, ref int offset, out short value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadInt16BigEndian(span);
        offset += sizeof(short);
    }

    public static void ReadUShort(this byte[] data, ref int offset, out ushort value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadUInt16BigEndian(span);
        offset += sizeof(ushort);
    }

    public static void ReadInt(this byte[] data, ref int offset, out int value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadInt32BigEndian(span);
        offset += sizeof(int);
    }

    public static void ReadUInt(this byte[] data, ref int offset, out uint value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadUInt32BigEndian(span);
        offset += sizeof(uint);
    }

    public static void ReadLong(this byte[] data, ref int offset, out long value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadInt64BigEndian(span);
        offset += sizeof(long);
    }

    public static void ReadULong(this byte[] data, ref int offset, out ulong value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadUInt64BigEndian(span);
        offset += sizeof(ulong);
    }

    public static void ReadFloat(this byte[] data, ref int offset, out float value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        int intValue = BinaryPrimitives.ReadInt32BigEndian(span);
        value = BitConverter.Int32BitsToSingle(intValue);
        offset += sizeof(float);
    }

    public static void ReadDouble(this byte[] data, ref int offset, out double value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        long longValue = BinaryPrimitives.ReadInt64BigEndian(span);
        value = BitConverter.Int64BitsToDouble(longValue);
        offset += sizeof(double);
    }

    public static void ReadBool(this byte[] data, ref int offset, out bool value)
    {
        value = data[offset] != 0;
        offset += sizeof(bool);
    }

    public static void ReadChar(this byte[] data, ref int offset, out char value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = (char)BinaryPrimitives.ReadUInt16BigEndian(span);
        offset += sizeof(char);
    }

    // ==== Write Methods (Big-Endian) ====
    public static void WriteByte(this byte[] data, ref int offset, byte value)
    {
        data[offset] = value;
        offset += sizeof(byte);
    }

    public static void WriteShort(this byte[] data, ref int offset, short value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteInt16BigEndian(span, value);
        offset += sizeof(short);
    }

    public static void WriteUShort(this byte[] data, ref int offset, ushort value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteUInt16BigEndian(span, value);
        offset += sizeof(ushort);
    }

    public static void WriteInt(this byte[] data, ref int offset, int value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteInt32BigEndian(span, value);
        offset += sizeof(int);
    }

    public static void WriteUInt(this byte[] data, ref int offset, uint value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteUInt32BigEndian(span, value);
        offset += sizeof(uint);
    }

    public static void WriteLong(this byte[] data, ref int offset, long value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteInt64BigEndian(span, value);
        offset += sizeof(long);
    }

    public static void WriteULong(this byte[] data, ref int offset, ulong value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteUInt64BigEndian(span, value);
        offset += sizeof(ulong);
    }

    public static void WriteFloat(this byte[] data, ref int offset, float value)
    {
        Span<byte> span = data.AsSpan(offset);
        int intValue = BitConverter.SingleToInt32Bits(value);
        BinaryPrimitives.WriteInt32BigEndian(span, intValue);
        offset += sizeof(float);
    }

    public static void WriteDouble(this byte[] data, ref int offset, double value)
    {
        Span<byte> span = data.AsSpan(offset);
        long longValue = BitConverter.DoubleToInt64Bits(value);
        BinaryPrimitives.WriteInt64BigEndian(span, longValue);
        offset += sizeof(double);
    }

    public static void WriteBool(this byte[] data, ref int offset, bool value)
    {
        data[offset] = value ? (byte)1 : (byte)0;
        offset += sizeof(bool);
    }

    public static void WriteChar(this byte[] data, ref int offset, char value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteUInt16BigEndian(span, value);
        offset += sizeof(char);
    }

    // ==== Little-Endian Support (Optional) ====
    public static void ReadIntLittleEndian(this byte[] data, ref int offset, out int value)
    {
        ReadOnlySpan<byte> span = data.AsSpan(offset);
        value = BinaryPrimitives.ReadInt32LittleEndian(span);
        offset += sizeof(int);
    }

    public static void WriteIntLittleEndian(this byte[] data, ref int offset, int value)
    {
        Span<byte> span = data.AsSpan(offset);
        BinaryPrimitives.WriteInt32LittleEndian(span, value);
        offset += sizeof(int);
    }

    // ... 其他类型的 Little-Endian 方法可类似实现
}