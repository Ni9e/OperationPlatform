/// <reference path="jquery-1.9.1-vsdoc.js" />

/*导出Excel*/
var idTmr = "";
function copy(tabid) {
    var oControlRange = document.body.createControlRange();
    oControlRange.add(tabid, 0);
    oControlRange.select();
    document.execCommand("Copy");
}

function Cleanup() {
    window.clearInterval(idTmr);
    CollectGarbage();
}

function createExportTable(id, array) {
    // 获取表的title和列名称
    var titleID = "#gview_" + id;
    var title = $(titleID).find(".ui-jqgrid-title").text();
    var column;

    var captionRow = '<tr id="newColName" class="ui-widget-content jqgrow ui-row-ltr">';
    for (var i = 0; i < array.length; i++) {
        column = $("#jqgh_" + id + "_" + array[i]).text();
        captionRow += '<td style="text-align:center; white-space:normal !important; height:auto !important; padding:0px;">' + column + '</td>';
    }
    captionRow += '</tr>';
    $('#' + id).find('.jqgfirstrow').after(captionRow);
    $('#' + id).find('.jqgfirstrow').after('<tr id="newTitle" class="ui-widget-content jqgrow ui-row-ltr"><td colspan="' + array.length + '" style="text-align:center;">' + title + '</td></tr>');

    // 移出第一行
    //$('#' + id).find('.jqgfirstrow').remove();
}

function clearAddRows() {
    $('#newTitle').remove();
    $('#newColName').remove();
}

function indexToName(index) {
    var name, groupId, groupIdx;
    if (index >= 1 && index <= 26) {
        name = String.fromCharCode(index+64);
    }
    else if (index > 26) {
        groupId = index / 26;
        groupIdx = index % 26;
        name = String.fromCharCode(groupId+64) + String.fromCharCode(groupIdx+64);
    }
    return name;
}

// 参考文档 http://blog.163.com/yellow_tulip/blog/static/94566655201071142841165/
function toExcel(tabid, jsData, sheetName) {
    var len = tabid.length;
    var columnIndex = 1;

    try {
        var xls = new ActiveXObject("Excel.Application");
    }
    catch (e) {
        alert("Excel没有安装或浏览器设置不正确！");
        return false;
    }
    xls.visible = true;
    var xlBook = xls.Workbooks.Add;
    var xlsheet = xlBook.Worksheets(1);
    xlBook.Worksheets(1).Activate;

    for (var i = 0; i < len; i++) {
        var tid = tabid[i].id;

        createExportTable(tid, jsData[tid]); // 创建表
        var rows = $('#' + tid).find("tr").length; // 表行数
        copy(tabid[i]); // 复制表        

        // 获取列宽
        var obj = $('#'+tid).find(".jqgfirstrow > td");
        var widthArr = new Array();
        for (var j = 0; j < obj.length; j++) {
            widthArr[j] = obj[j].style.width;
        }

        // 设置excel列宽
        var cellsLen = tabid[i].rows(0).cells.length;
        for (var k = 0; k < cellsLen; k++) {
            xlsheet.Columns(k + columnIndex).ColumnWidth = parseInt(widthArr[k]) / 8.266;
        }

        // 写入excel
        var start = indexToName(columnIndex);
        var end = indexToName(cellsLen + columnIndex - 1);
        xlsheet.Paste(xlsheet.Range(start + "1:" + end + rows));

        // 设置表格格式
        xlsheet.Range(start + "2").Interior.colorindex = 45; //背景颜色 http://www.cnblogs.com/herbert/archive/2010/06/30/1768259.html
        xlsheet.Range(start + "3:" + end + "3").Interior.colorindex = 15;

        xlsheet.Range(start + "2:" + end + "3").Font.Bold = true;

        xlsheet.Range(start + "2:" + end + rows).Borders(1).LineStyle = 1 //区域边框
        xlsheet.Range(start + "2:" + end + rows).Borders(2).LineStyle = 1
        xlsheet.Range(start + "2:" + end + rows).Borders(3).LineStyle = 1
        xlsheet.Range(start + "2:" + end + rows).Borders(4).LineStyle = 1

        columnIndex = columnIndex + cellsLen + 1; // 调整列索引
        clearAddRows();
    }
    xlsheet.Cells.Font.Size = 9; // 设置字体
    xlsheet.Name = sheetName;
    xls = null;
    idTmr = window.setInterval("Cleanup();", 1);    
}
