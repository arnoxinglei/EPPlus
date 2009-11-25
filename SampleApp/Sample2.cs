/*******************************************************************************
 * You may amend and distribute as you like, but don't remove this header!
 * 
 * All rights reserved.
 * 
 * EPPlus is an Open Source project provided under the 
 * GNU General Public License (GPL) as published by the 
 * Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
 * 
 * EPPlus provides server-side generation of Excel 2007 spreadsheets.
 * See http://www.codeplex.com/EPPlus for details.
 *
 * EPPlus is a fork of the ExcelPackage project
 * 
 * The GNU General Public License can be viewed at http://www.opensource.org/licenses/gpl-license.php
 * If you unfamiliar with this license or have questions about it, here is an http://www.gnu.org/licenses/gpl-faq.html
 * 
 * The code for this project may be used and redistributed by any means PROVIDING it is 
 * not sold for profit without the author's written consent, and providing that this notice 
 * and the author's name and all copyright notices remain intact.
 * 
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 *
 *
 * Code change notes:
 * 
 * Author							Change						Date
 *******************************************************************************
 * Jan K�llman		Added		10-SEP-2009
 *******************************************************************************/

/*
 * Sample code demonstrating how to generate Excel spreadsheets on the server using 
 * Office Open XML and the ExcelPackage wrapper classes.
 * 
 * ExcelPackage provides server-side generation of Excel 2007 spreadsheets.
 * See http://www.codeplex.com/ExcelPackage for details.
 * 
 * Sample 2: Reads a column of data from the spreadsheet generated by Sample 1
 * 
 * Copyright 2007 � Dr John Tunnicliffe 
 * mailto:dr.john.tunnicliffe@btinternet.com
 * All rights reserved.
 * 
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OfficeOpenXml;

namespace ExcelPackageSamples
{
	/// <summary>
	/// Simply opens an existing file and reads some values and properties
	/// </summary>
	class Sample2
	{
		public static void RunSample2(string FilePath)
		{
			Console.WriteLine("Reading column 2 of {0}", FilePath);
			Console.WriteLine();

			FileInfo existingFile = new FileInfo(FilePath);
			using (ExcelPackage xlPackage = new ExcelPackage(existingFile))
			{
				// get the first worksheet in the workbook
				ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[1];
				int iCol = 2;  // the column to read
				
				// output the data in column 2
				for (int iRow = 1; iRow < 5; iRow++)
					Console.WriteLine("\tCell({0},{1}).Value={2}", iRow, iCol, worksheet.Cells[iRow, iCol].Value);

				// output the formula in row 6
				Console.WriteLine("\tCell({0},{1}).Formula={2}", 5, iCol, worksheet.Cells[5, iCol].Formula);
                Console.WriteLine("\tCell({0},{1}).FormulaR1C1={2}", 5, iCol, worksheet.Cells[5, iCol].FormulaR1C1);

			} // the using statement automatically calls Dispose() which closes the package.

			Console.WriteLine();
			Console.WriteLine("Sample 2 complete");
			Console.WriteLine();
		}
	}
}
