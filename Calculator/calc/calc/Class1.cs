using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

public class calculations
{
	private List<double> nums = new List<double>();

	private double y;
	private string text;

	public double Gety() => y;
	public void Sety(double val)
	{
		y = val;
	}
	public string GetText()
	{
		return text;
	}
	public void Settext(string val)
	{
		text = val;
	}
	public string Plus(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		y = double.Parse(words[1]);
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] += y;
		}
		TextRebuild();
		return text;
	}

	public string Minus(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		y = double.Parse(words[1]);
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] -= y;
		}
		TextRebuild();
		return text;
	}


	public string Multiply(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		y = double.Parse(words[1]);
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] *= y;
		}
		TextRebuild();
		return text;
	}

	public string Divide(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		y = double.Parse(words[1]);
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] /= y;
		}
		TextRebuild();
		return text;
	}

	public string Power(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		y = double.Parse(words[1]);
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] = Math.Pow(nums[i], y);
		}
		TextRebuild();
		return text;
	}
	public void Square()
	{
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] = Math.Pow(nums[i], 2);
		}
		TextRebuild();

	}
	public void SquareRoot()
	{
		TextToNums();
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] = Math.Pow(nums[i], 0.5);
		}
		TextRebuild();
	}

	public string Log(string val)
	{
		text = val;
		string[] words = text.Split(new char[] { 'L' }, StringSplitOptions.RemoveEmptyEntries);
		text = words[0];
		words[1] = words[1].Substring(2);
		y = double.Parse(words[1]);
		TextToNums();
		double osn = Math.Log(y);
		for (int i = 0; i < nums.Count; ++i)
		{
			nums[i] = Math.Log(nums[i]) / osn;
		}
		TextRebuild();
		return text;
	}

	public void Factorial()
	{
		TextToNums();

		for (int i = 0; i < nums.Count; ++i)
		{
			double temp = 1;
			for (double j = 1; j <= nums[i]; ++j)
			{
				temp *= j;
			}
			nums[i] = temp;
		}
		TextRebuild();
	}

	public void Disp()
	{
		TextToNums();

	}

	public void Median()
	{
		TextToNums();

		double sum = 0;
		foreach (double a in nums)
		{
			sum += a;
		}
		double median = sum / nums.Count;

		text = median.ToString();
		nums.Clear();

	}


	//ФУНКЦИИ ДЛЯ ВСЕХ
	private void TextToNums()
	{
		CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");


		string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string s in words)
		{
			try
			{
				nums.Add(double.Parse(s));
			}
			catch (Exception ex)
			{
				nums.Add(0);
				Console.WriteLine(ex.Message);
			}

		}
		text = "";
	}


	private void TextRebuild()
	{

		CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
		text = "";
		foreach (double a in nums)
		{
			try
			{
				text = text + a.ToString() + " ";
			}
			catch (Exception ex)
			{
				text += "";
				Console.WriteLine(ex.Message);
			}

		}
	}

}
