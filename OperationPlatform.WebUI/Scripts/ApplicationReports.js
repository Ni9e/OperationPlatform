// 报表Action和id设置
// application
var loadUrlApplicationAvailability = "GetApplicationAvailability";
var loadUrlApplicationCPUUsed = "GetApplicationCPUUsed";
var loadUrlApplicationMemoryUsed = "GetApplicationMemoryUsed";
var loadUrlApplicationCurrentStatus = "GetApplicationCurrentStatus";

var gridApplicationAvailability = "#gridApplicationAvailability";
var gridApplicationCPUUsed = "#gridApplicationCPUUsed";
var gridApplicationMemoryUsed = "#gridApplicationMemoryUsed";
var gridApplicationCurrentStatus = "#gridApplicationCurrentStatus";

/*-------------------------------------------------------------------*/

function addCSS(id) {
    $(id).closest("div.ui-jqgrid-view")
                  .children("div.ui-jqgrid-titlebar")
                  .css("text-align", "center")
                  .children("span.ui-jqgrid-title")
                  .css("float", "none");
};

$(function () {
    configGrid();

    // 报表Title设置
    addCSS(gridApplicationAvailability);
    addCSS(gridApplicationCPUUsed);
    addCSS(gridApplicationMemoryUsed);
    addCSS(gridApplicationCurrentStatus);

    $("#result").hide();

    $("#btSubmit").click(function () {
        var para = $("#txtSearch").val();

        // 报表request url设置
        var queryUrlApplicationAvailablity = loadUrlApplicationAvailability + "?datetime=" + para;
        var queryUrlApplicationCPUUsed = loadUrlApplicationCPUUsed + "?datetime=" + para;
        var queryUrlApplicationMemoryUsed = loadUrlApplicationMemoryUsed + "?datetime=" + para;
        var queryUrlApplicationCurrentStatus = loadUrlApplicationCurrentStatus + "?datetime=" + para;

        // 报表查询
        $(gridApplicationAvailability).jqGrid('setGridParam', { url: queryUrlApplicationAvailablity }).trigger("reloadGrid");
        $(gridApplicationCPUUsed).jqGrid('setGridParam', { url: queryUrlApplicationCPUUsed }).trigger("reloadGrid");
        $(gridApplicationMemoryUsed).jqGrid('setGridParam', { url: queryUrlApplicationMemoryUsed }).trigger("reloadGrid");
        $(gridApplicationCurrentStatus).jqGrid('setGridParam', { url: queryUrlApplicationCurrentStatus }).trigger("reloadGrid");

        // 报表布局设置 
        $("#gbox_" + gridApplicationAvailability.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridApplicationCPUUsed.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridApplicationMemoryUsed.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridApplicationCurrentStatus.substr(1)).addClass("gridfloat");

        $("#result").show();
    });
});

$(document).keydown(function (e) {
    if (e.keyCode == 13) {
        $("#btSubmit").click();
    }
});

function configGrid() {      
    $(gridApplicationAvailability).jqGrid({
        url: loadUrlApplicationAvailability,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Application Name", "Application Availability"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "ApplicationName", index: "ApplicationName", align: "center", width: "450px" },
                        { name: "AverangeApplicationAvailability", index: "AverangeApplicationAvailability", align: "center", width: "120px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (val.substr(0, val.length - 1) <= 80) return "style='background-color: red'"; } }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: true,
        caption: "应用监控Availability"
    });

    $(gridApplicationCPUUsed).jqGrid({
        url: loadUrlApplicationCPUUsed,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Application Name", "Component Name", "Average Percent CPU", "Peak Percent CPU"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "ApplicationName", index: "ApplicationName", align: "center", width: "450px" },
                        { name: "ComponentName", index: "ComponentName", align: "center", width: "300px" },
                        { name: "AveragePercentCPU", index: "AveragePercentCPU", align: "center", width: "100px" },
                        { name: "PeakPercentCPU", index: "PeakPercentCPU", align: "center", width: "100px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (parseFloat(val.substr(0, val.length - 1)) >= 30 * parseFloat(rawObject[3].valueOf("AveragePercentCPU").substr(0, rawObject[3].valueOf("AveragePercentCPU").length - 1)) && parseFloat(rawObject[3].valueOf("AveragePercentCPU").substr(0, rawObject[3].valueOf("AveragePercentCPU").length - 1)) != 0) return "style='background-color: red'"; } } // 最大值大于平均值的30倍
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: true,
        caption: "应用CPU使用率"
    });

    $(gridApplicationMemoryUsed).jqGrid({
        url: loadUrlApplicationMemoryUsed,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Application Name", "Component Name", "Average Percent Physical Memory", "Peak Percent Physical Memory"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "ApplicationName", index: "ApplicationName", align: "center", width: "450px" },
                        { name: "ComponentName", index: "ComponentName", align: "center", width: "300px" },
                        { name: "AveragePercentMemory", index: "AveragePercentMemory", align: "center", width: "100px" },
                        { name: "PeakPercentMemory", index: "PeakPercentMemory", align: "center", width: "100px" } // 最大值大于平均值的30倍
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: true,
        caption: "应用Memory使用率"
    });

    $(gridApplicationCurrentStatus).jqGrid({
        url: loadUrlApplicationCurrentStatus,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Application Name", "Application Status", "Component Name", "Component Status"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "ApplicationName", index: "ApplicationName", align: "center", width: "450px" },
                        { name: "ApplicationStatus", index: "ApplicationStatus", align: "center", width: "100px" },
                        { name: "ComponentName", index: "ComponentName", align: "center", width: "300px" },
                        { name: "ComponentStatus", index: "ComponentStatus", align: "center", width: "100px"} // 最大值大于平均值的30倍
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: true,
        caption: "应用当前状态"
    });
} 