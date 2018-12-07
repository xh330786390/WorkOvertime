using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.SS.UserModel;
using System.Data;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using Common.NLog;

namespace WorkOvertime.Files
{
    public class ExcelFile
    {
        /// <summary>
        /// 工作表
        /// </summary>
        private XSSFWorkbook _workBook = null;

        private int startRow = 5 - 1;

        #region [公共方法]
        /// <summary>
        /// Npoi读取文件
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <returns>数据表</returns>
        public List<RecodeModel> Read(string file)
        {
            try
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    _workBook = new XSSFWorkbook(fs);
                    int sheetNum = _workBook.NumberOfSheets;
                    for (int index = 0; index < sheetNum; index++)
                    {
                        ISheet sheet = _workBook.GetSheetAt(index);
                        if (sheet.SheetName != SysConst.SheetName) continue;
                        List<RecodeModel> list = getTable(sheet);
                        return list;
                    }
                }
            }
            catch (Exception er)
            {
                LogHelper.Error("ExcelFile Read = ", er.Message);
            }

            return null;
        }

        private List<RecodeModel> getTable(ISheet sheet)
        {
            List<RecodeModel> list = new List<RecodeModel>();

            //@1.获取数据
            for (int i = startRow; i <= sheet.LastRowNum; i++)
            {
                string departmentName = sheet.GetRow(i).GetCell(1).ToString(); //部门
                if (departmentName == SysConst.DepartmentName)
                {
                    RecodeModel item = new RecodeModel();
                    item.Name = sheet.GetRow(i).GetCell(0).ToString(); //姓名
                    if (item.Name != "陈祖武") continue;
                    item.DepartmentName = departmentName; //部门
                    item.Week = sheet.GetRow(i).GetCell(5).ToString(); //星期
                    item.StartTime = sheet.GetRow(i).GetCell(7).ToString(); //上班时间
                    item.EndTime = sheet.GetRow(i).GetCell(9).ToString(); //下班时间
                    if (item.EndTime.Contains("次日"))
                    {
                        item.EndTime = "23:00";
                    }
                    item.OverTimeApply = sheet.GetRow(i).GetCell(15).ToString(); //加班申请

                    list.Add(item);
                }
            }
            return list;
        }


        /// <summary>  
        /// 获取单元格类型(xls)  
        /// </summary>  
        /// <param name="cell"></param>  
        /// <returns></returns>  
        private object GetValueTypeForXls(XSSFCell cell)
        {
            if (cell == null) return null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                default:
                    return "=" + cell.CellFormula;
            }
        }
        #endregion
    }
}
