using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 계산기3
{
	public partial class Form1 : Form
	{
		// This determine which variable to change.
		// If it's 0, affect operand1, if 2, affact operand2
		int operandChange = 0;
		// operand1 = null  건드리지 않았으면 널  조건문 비교 하려고 씀 
		private string operand1 = null;
		private string operand2 = null;
		private string operation = null;
		public Form1()
		{
			InitializeComponent();
			button1.Click += (sender, e) => TextAdd(1);
			button2.Click += (sender, e) => TextAdd(2);
			button3.Click += (sender, e) => TextAdd(3);
			button4.Click += (sender, e) => TextAdd(4);
			button5.Click += (sender, e) => TextAdd(5);
			button6.Click += (sender, e) => TextAdd(6);
			button7.Click += (sender, e) => TextAdd(7);
			button8.Click += (sender, e) => TextAdd(8);
			button9.Click += (sender, e) => TextAdd(9);
			button10.Click += (sender, e) => TextAdd(0);

			NumAdd.Click += (sender, e) => OperationA('+');
			NumSub.Click += (sender, e) => OperationA('-');
			NumDivide.Click += (sender, e) => OperationA('/');
			NumMultiple.Click += (sender, e) => OperationA('*');

			buttonEqual.Click += (sender, e) => Equal_result();

			Reset.Click += (sender, e) => ResetAll();
			Decimal.Click += (sender, e) => DecimalPoint();
		}

		private void TextAdd(int num)
		{
			if (operandChange == 0)
			{
				operand1 += num;
				textBoxWorkspace.Text += num;
			}
			else 
			{
				operand2 += num;
				textBoxWorkspace.Text += num;
			}
			
		}
		private void OperationA(char Oper)
		{
			if (operation == null)
			{
				operation += Oper;
				textBoxWorkspace.Text += Oper;
			}
			operandChange = 1;// operand2에 input number 
		}
		private void Equal_result()
		{
			double result = 0;
			switch (operation)
			{
				case "+": result = double.Parse(operand1) + double.Parse(operand2); break;
				case "-": result = double.Parse(operand1) - double.Parse(operand2); break;
				case "*": result = double.Parse(operand1) * double.Parse(operand2); break;
				case "/": result = double.Parse(operand1) / double.Parse(operand2); break;
			};

			textBoxLast.Text = textBoxWorkspace.Text;// 계산식을  textBoxLast 위 쪽에있는 텍스트 박스로 이동
			textBoxWorkspace.Text = result.ToString();// 계산 결과값으로 초기화
			

			operand1 = result.ToString();
			operand2 = null;
			operation = null;

		}
		private void ResetAll()
		{
			operandChange = 0;
			operand1 = null;
			operand2 = null;
			operation = null;
			textBoxWorkspace.Clear();
			textBoxLast.Clear();
		}
		private void DecimalPoint()
		{
			if (operandChange == 0)
			{
				if (operand1.Contains('.') == false)
				{
					operand1 += '.';
					textBoxWorkspace.Text += '.';
				}
			}
			else
			{
				if (operand2.Contains('.') == false)
				{
					operand2 += '.';
					textBoxWorkspace.Text += '.';
				}
			}
		}

		
	}
}
