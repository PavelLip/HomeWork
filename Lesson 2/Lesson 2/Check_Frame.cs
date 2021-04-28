using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Check_Frame
    {
        public char SymBranch = '*';
        public DateTime DateOfSale = DateTime.Now;
        public Double PriceAllProduct;

        public Check_Frame(int receiptHeight, int receiptWight)
        {
            Console.SetWindowSize(receiptHeight, receiptWight);
            Console.SetBufferSize(receiptHeight, receiptWight);

            HorizontailLine upLine = new HorizontailLine(1, receiptHeight - 3, 0, '_');
            verticalLine leftLine = new verticalLine(1, 9, 0, '|');
            verticalLine rightLine = new verticalLine(1, 9, receiptHeight - 2, '|');

            upLine.draw();
            leftLine.draw();
            rightLine.draw();

            string NameOrganization = '\u0022' + "ООО" + '\u0022' + " Рога и Копыта";
            string NameCheck = "Номер чека: ";
            string NameCassir = "Иванова";
            string PostamentNameCassir = "Кассир: ";
            int NumberCheck = 10543;

            Console.SetCursorPosition((receiptHeight - NameOrganization.Length) / 2, 2);
            Console.WriteLine(NameOrganization);

            Console.SetCursorPosition((receiptHeight - PostamentNameCassir.Length - NameCassir.Length) / 2, 3);
            Console.WriteLine(PostamentNameCassir + NameCassir);

            Console.SetCursorPosition((receiptHeight - NameCheck.Length - NumberCheck.ToString().Length) / 2, 4);
            Console.WriteLine(NameCheck + NumberCheck);

            HorizontailLine DownLineсCap = new HorizontailLine(1, receiptHeight - 3, 5, '*');
            DownLineсCap.draw();

        }
        public void TotalAmount(Double PriceProduct, Double CountProduct, int receiptHeight, int receiptWight, char sym, int PositionCursoreWidth)
        {
            verticalLine leftLine = new verticalLine(PositionCursoreWidth, PositionCursoreWidth + 4, 0, '|');
            verticalLine rightLine = new verticalLine(PositionCursoreWidth, PositionCursoreWidth + 4, receiptHeight - 2, '|');
            leftLine.draw();
            rightLine.draw();

            string NameResulc = "Всего";
            int PositionCursoreResul = PositionCursoreWidth + 2;

            PriceAllProduct = Math.Round(PriceAllProduct + PriceProduct * CountProduct, 2);
            Console.SetCursorPosition(receiptHeight - PriceAllProduct.ToString().Length - 2, PositionCursoreResul);
            Console.WriteLine(PriceAllProduct);

            Console.SetCursorPosition(1, PositionCursoreResul);
            Console.WriteLine(NameResulc);

            HorizontailLine SymbolPriceTotal = new HorizontailLine(1 + NameResulc.Length, receiptHeight - PriceAllProduct.ToString().Length - 3, PositionCursoreResul, sym);
            SymbolPriceTotal.draw();

            HorizontailLine BranchLineUp = new HorizontailLine(1, receiptHeight - 3, PositionCursoreResul - 1, SymBranch);
            BranchLineUp.draw();

            HorizontailLine ClearString = new HorizontailLine(1, receiptHeight - 3, PositionCursoreResul + 1, ' ');
            ClearString.draw();
            Console.SetCursorPosition((receiptHeight - DateOfSale.ToString().Length) / 2, PositionCursoreResul + 1);

            Console.WriteLine(DateOfSale);

            HorizontailLine downLine = new HorizontailLine(1, receiptHeight - 3, PositionCursoreResul + 2, '_');
            downLine.draw();

        }

        public void AddProduct(string Product, Double CountProduct, Double price, int receiptHeight, int receiptWight, char sym, int PositionCursoreWidth)
        {
            string NameProductOfCount = Product + " x " + CountProduct + " тонн";

            Console.SetCursorPosition(1, PositionCursoreWidth);
            Console.WriteLine(NameProductOfCount);

            Console.SetCursorPosition(receiptHeight - (price * CountProduct).ToString().Length - 2, PositionCursoreWidth);
            Console.WriteLine(price * CountProduct);

            HorizontailLine SymbolPriceTotal = new HorizontailLine(1 + NameProductOfCount.Length, receiptHeight - (price * CountProduct).ToString().Length - 3, PositionCursoreWidth, sym);
            SymbolPriceTotal.draw();

            TotalAmount(price, CountProduct, receiptHeight, receiptWight, sym, PositionCursoreWidth);
        }
    }
}
