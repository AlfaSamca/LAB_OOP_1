using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace LB_1
{
	public class JIBitArray
	{
		private ArrayList _Bits = new ArrayList(); //создание хранилища "бит"
												   //блок конструкторов 
		#region Constructors 
		public JIBitArray()//пустой объкт 
		{ }
		public JIBitArray(byte[] bits)//объект для инициализация массива бит со значениями byte
		{
			string st;
			foreach (byte b in bits)
			{
				st = FixLength(Convert.ToString(b, 2), 8);
				AddBits(st);
			}
		}

		public JIBitArray(int[] bits)//объект для инициализация массива бит со значениями int
		{
			string st;
			foreach (int i in bits)
			{
				st = FixLength(Convert.ToString(i, 2), 32);
				AddBits(st);
			}
		}

		public JIBitArray(long[] bits)//объект для инициализация массива бит со значениями long
		{
			string st;
			foreach (long i in bits)
			{
				st = FixLength(Convert.ToString(i, 2), 64);
				AddBits(st);
			}
		}

		public JIBitArray(short[] bits)//объект для инициализация массива бит со значениями bits
		{
			string st;
			foreach (short i in bits)
			{
				st = FixLength(Convert.ToString(i, 2), 16);
				AddBits(st);
			}
		}

		public JIBitArray(bool[] bits)//объект для инициализация массива бит со значениями bool
		{
			foreach (bool b in bits)
			{
				_Bits.Add(b);
			}
		}

		public JIBitArray(int length)//заполнение массива количеством length элементов нулями(false)
		{
			AddBlock(length, false);
		}

		public JIBitArray(int length, bool defaultValue)//заполнение массива количеством length элементов defaultValue(true or false)
		{
			AddBlock(length, defaultValue);
		}

		private void AddBlock(int length, bool Value)//метод непосредственно заполнения массива//
		{
			for (int i = 0; i < length; i++)
				_Bits.Add(Value);
		}
		#endregion

		private string FixLength(string num, int length)//дополнение строкового представления бит объекта нулями впереди 
		{
			while (num.Length < length)
				num = num.Insert(0, "0");
			return num;
		}

		private void AddBits(string bits)//метод помещения значения в хранилище(помещение имеено в конец нашего списка)
		{
			foreach (char ch in bits)
			{
				if (ch == '0')
					_Bits.Add(false);
				else if (ch == '1')
					_Bits.Add(true);
				else
					throw (new ArgumentException("бит содержит ни 1, ни 0"));
			}
		}


		public override string ToString()//строковое представление массива бит
		{
			string rt = string.Empty;
			foreach (bool b in _Bits)
			{
				if (b == false)
					rt += '0';
				else
					rt += '1';
			}
			return rt;
		}


		public void Insert(int index, bool Value)//вставка значения в конкретную позицию
		{
			_Bits.Insert(index, Value);
		}


		public void Add(bool Value)//вствка значения в конец
		{
			_Bits.Add(Value);
		}


		public void Set(int index, bool Value)//установка(замена) значения на конкретной позиции
		{
			_Bits[index] = Value;
		}


		public bool Get(int index)//получение значения по индексу
		{
			return (bool)_Bits[index];
		}


		public int Count//возвращение количества элементов в массив
		{
			get
			{
				return _Bits.Count;
			}
		}


		public void SetAll(bool Value)//установка всех битов в массиве в знвчение value(true or false)
		{
			for (int i = 0; i < _Bits.Count; i++)
			{
				_Bits[i] = Value;
			}
		}


		public JIBitArray Not()//инверсия всех битов 
		{
			JIBitArray RArray = new JIBitArray(_Bits.Count);
			for (int i = 0; i < _Bits.Count; i++)
			{
				if ((bool)_Bits[i] == true)
					RArray.Set(i, false);
				else
					RArray.Set(i, true);
			}
			return RArray;
		}



		public JIBitArray SubJIBitArray(int index, int length)//возвращение нового массива бит со значениями исходного в количестве length от index
		{
			JIBitArray RArray = new JIBitArray(length);
			int c = 0;
			for (int i = index; i < index + length; i++)
				RArray.Set(c++, (bool)_Bits[i]);
			return RArray;
		}


		public JIBitArray Or(JIBitArray Value)//выполнение операции логического ИЛИ с другим массивом бит Value
		{
			JIBitArray RArray;
			int Max = _Bits.Count > Value._Bits.Count ? _Bits.Count : Value._Bits.Count;

			RArray = new JIBitArray(Max);
			RArray._Bits = this._Bits;

			if (Max == RArray._Bits.Count)
				FixLength(Value, Max);
			else
				FixLength(RArray, Max);

			for (int i = 0; i < Max; i++)
				RArray.Set(i, (bool)Value._Bits[i] | (bool)RArray._Bits[i]);

			return RArray;
		}


		public JIBitArray And(JIBitArray Value)//выполнение операции логического И с другим массивом бит Value
		{
			JIBitArray RArray;
			int Max = _Bits.Count > Value._Bits.Count ? _Bits.Count : Value._Bits.Count;

			RArray = new JIBitArray(Max);
			RArray._Bits = this._Bits;

			if (Max == RArray._Bits.Count)
				FixLength(Value, Max);
			else
				FixLength(RArray, Max);

			for (int i = 0; i < Max; i++)
				RArray.Set(i, (bool)Value._Bits[i] & (bool)RArray._Bits[i]);

			return RArray;
		}


		public JIBitArray Xor(JIBitArray Value)//выполнение операции исключающего ИЛИ с другим массивом бит Value
		{
			JIBitArray RArray;
			int Max = _Bits.Count > Value._Bits.Count ? _Bits.Count : Value._Bits.Count;

			RArray = new JIBitArray(Max);
			RArray._Bits = this._Bits;

			if (Max == RArray._Bits.Count)
				FixLength(Value, Max);
			else
				FixLength(RArray, Max);

			for (int i = 0; i < Max; i++)
				RArray.Set(i, (bool)Value._Bits[i] ^ (bool)RArray._Bits[i]);

			return RArray;
		}

		#region Array Convertors

		public long[] GetLong()//представление массива бит в виде массива чисел типа long
		{
			int ArrayBound = (int)Math.Ceiling((double)this._Bits.Count / 64);
			long[] Bits = new long[ArrayBound];
			JIBitArray Temp = new JIBitArray();
			Temp._Bits = this._Bits;
			Temp = FixLength(Temp, ArrayBound * 64);
			for (int i = 0; i < Temp._Bits.Count; i += 64)
			{
				Bits[i / 64] = Convert.ToInt64(Temp.SubJIBitArray(i, 64).ToString(), 2);
			}
			return Bits;
		}


		public int[] GetInt()//представление массива бит в виде массива чисел типа int
		{
			int ArrayBound = (int)Math.Ceiling((double)this._Bits.Count / 32);
			int[] Bits = new int[ArrayBound];
			JIBitArray Temp = new JIBitArray();
			Temp._Bits = this._Bits;
			Temp = FixLength(Temp, ArrayBound * 32);

			for (int i = 0; i < Temp._Bits.Count; i += 32)
			{
				Bits[i / 32] = Convert.ToInt32(Temp.SubJIBitArray(i, 32).ToString(), 2);
			}
			return Bits;
		}


		public short[] GetShorts()//представление массива бит в виде массива чисел типа shorts
		{
			int ArrayBound = (int)Math.Ceiling((double)this._Bits.Count / 16);
			short[] Bits = new short[ArrayBound];
			JIBitArray Temp = new JIBitArray();
			Temp._Bits = this._Bits;
			Temp = FixLength(Temp, ArrayBound * 16);

			for (int i = 0; i < Temp._Bits.Count; i += 16)
			{
				Bits[i / 16] = Convert.ToInt16(Temp.SubJIBitArray(i, 16).ToString(), 2);
			}
			return Bits;
		}


		public byte[] GetBytes()//представление массива бит в виде массива чисел типа byte
		{
			int ArrayBound = (int)Math.Ceiling((double)this._Bits.Count / 8);
			byte[] Bits = new byte[ArrayBound];
			JIBitArray Temp = new JIBitArray();
			Temp._Bits = this._Bits;
			Temp = FixLength(Temp, ArrayBound * 8);

			for (int i = 0; i < Temp._Bits.Count; i += 8)
			{
				Bits[i / 8] = Convert.ToByte(Temp.SubJIBitArray(i, 8).ToString(), 2);
			}
			return Bits;
		}
		#endregion


		public JIBitArray ShiftLeft(int count)//логический сдвиг массива влево
		{
			JIBitArray RArray = new JIBitArray();
			RArray._Bits = this._Bits;
			for (int i = 0; i < count; i++)
			{
				RArray._Bits.RemoveAt(0);
				RArray._Bits.Add(false);
			}
			return RArray;
		}


		public JIBitArray ShiftRight(int count) //логический сдвиг массива вправо
		{
			JIBitArray RArray = new JIBitArray();
			RArray._Bits = this._Bits;
			for (int i = 0; i < count; i++)
			{
				RArray._Bits.RemoveAt(RArray._Bits.Count - 1);
				RArray._Bits.Insert(0, false);
			}
			return RArray;
		}


		public JIBitArray RemoveBeginingZeros()//удаление всех значений false до первого true 
		{
			JIBitArray RArray = new JIBitArray();
			RArray._Bits = this._Bits;
			while (RArray._Bits.Count != 0 && (bool)RArray._Bits[0] == false)
				RArray._Bits.RemoveAt(0);
			return RArray;
		}

		#region Static

		public static JIBitArray FixLength(JIBitArray Value, int length)//дополнение массива бит Value нулями в количестве lenght
		{
			if (length < Value._Bits.Count)
				throw (new ArgumentException("длинна должна быть больше или ровна Bits.Length"));
			while (Value._Bits.Count < length)
				Value._Bits.Insert(0, false);
			return Value;
		}
		#endregion

		#region Operators
		public static JIBitArray operator &(JIBitArray Bits1, JIBitArray Bits2)//перегрузка оператора &
		{
			return Bits1.And(Bits2);
		}

		public static JIBitArray operator |(JIBitArray Bits1, JIBitArray Bits2)//перегрузка оператора |
		{
			return Bits1.Or(Bits2);
		}

		public static JIBitArray operator ^(JIBitArray Bits1, JIBitArray Bits2)//перегрузка оператора ^
		{
			return Bits1.Xor(Bits2);
		}

		public static JIBitArray operator >>(JIBitArray Bits, int count)//перегрузка оператора >>
		{
			return Bits.ShiftRight(count);
		}

		public static JIBitArray operator <<(JIBitArray Bits, int count)//перегрузка оператора <<
		{
			return Bits.ShiftLeft(count);
		}
		#endregion
	}
}
