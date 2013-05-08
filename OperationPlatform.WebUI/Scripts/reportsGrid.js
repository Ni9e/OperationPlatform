// 报表Action和id设置
// device
var loadUrlMemoryUsed = "GetMemoryUsedInformation";
var loadUrlAvailability = "GetAvailability";
var loadUrlCPUUsed = "GetCPUUsed";
var loadUrlDeviceNetwork = "GetDeviceNetwork";
var loadUrlDeviceDiskUsed = "GetDeviceDiskUsed";

var gridMemoryUsed = "#gridMemoryUsed";
var gridAvailability = "#gridAvailability";
var gridCPUUsed = "#gridCPUUsed";
var gridDeviceNetwork = "#gridDeviceNetwork";
var gridDeviceDiskUsed = "#gridDeviceDiskUsed"
/*-------------------------------------------------------------------*/

function addCSS(id) {
    $(id).closest("div.ui-jqgrid-view")
                  .children("div.ui-jqgrid-titlebar")
                  .css("text-align", "center")
                  .children("span.ui-jqgrid-title")
                  .css("float", "none");
};

function deviceNetworkCellattr(rowId, val, rawObject, cm, rdata) {
    if (rawObject[2].valueOf("AvgReceive").substr(0, 1) == 0 &&
        rawObject[3].valueOf("MaxReceive").substr(0, 1) == 0 &&
        rawObject[4].valueOf("AvgTrans").substr(0, 1) == 0 &&
        rawObject[5].valueOf("MaxTrans").substr(0, 1) == 0)
        return "style='background-color: red'"; 
};

$(function () {
    configGrid();

    // 报表Title设置
    addCSS(gridMemoryUsed);
    addCSS(gridAvailability);
    addCSS(gridCPUUsed);
    addCSS(gridDeviceNetwork);
    addCSS(gridDeviceDiskUsed);

    $("#result").hide();
    $("#btnExport").hide();

    $("#btSubmit").click(function () {
        var para = $("#txtSearch").val();

        // 报表request url设置
        var queryUrlMemoryUsed = loadUrlMemoryUsed + "?datetime=" + para;
        var queryUrlAvailability = loadUrlAvailability + "?datetime=" + para;
        var queryUrlCPUUsed = loadUrlCPUUsed + "?datetime=" + para;
        var queryUrlDeviceNetwork = loadUrlDeviceNetwork + "?datetime=" + para;
        var queryUrlDeviceDiskUsed = loadUrlDeviceDiskUsed + "?datetime=" + para;        

        // 报表查询
        $(gridMemoryUsed).jqGrid('setGridParam', { url: queryUrlMemoryUsed }).trigger("reloadGrid");
        $(gridAvailability).jqGrid('setGridParam', { url: queryUrlAvailability }).trigger("reloadGrid");
        $(gridCPUUsed).jqGrid('setGridParam', { url: queryUrlCPUUsed }).trigger("reloadGrid");
        $(gridDeviceNetwork).jqGrid('setGridParam', { url: queryUrlDeviceNetwork }).trigger("reloadGrid");
        $(gridDeviceDiskUsed).jqGrid('setGridParam', { url: queryUrlDeviceDiskUsed }).trigger("reloadGrid");
        
        // 报表布局设置
        $("#gbox_" + gridAvailability.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridCPUUsed.substr(1)).addClass("gridClear");
        $("#gbox_" + gridMemoryUsed.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridDeviceDiskUsed.substr(1)).addClass("gridfloat");
        $("#gbox_" + gridDeviceNetwork.substr(1)).addClass("gridfloat");

        $("#result").show();
        $("#btnExport").show();
        $('.ui-icon.ui-icon-circle-triangle-s').click();
    });
});

$(document).keydown(function (e) {
    if (e.keyCode == 13) {
        $("#btSubmit").click();
    }
});

function configGrid() {
    $(gridMemoryUsed).jqGrid({
        url: loadUrlMemoryUsed,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Average Memory Load", "Peak Memory Used", "Total Memory", "Average Percent Memory Used"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "AvgMemoryUsed", index: "AvgMemoryUsed", align: "center", width: "120px" },
                        { name: "MaxMemoryUsed", index: "MaxMemoryUsed", align: "center", width: "120px" },
                        { name: "TotalMemory", index: "TotalMemory", align: "center", width: "120px" },
                        { name: "AvgPercentMemoryUsed", index: "AvgPercentMemoryUsed", align: "center", width: "120px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (val.substr(0, val.length - 1) >= 90) return "style='background-color: red'"; if (val.substr(0, val.length - 1) < 90 && val.substr(0, val.length - 1) >= 80) return "style='background-color: yellow'"; } }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: false,
        caption: "设备memory使用率"
    });

    $(gridDeviceDiskUsed).jqGrid({
        url: loadUrlDeviceDiskUsed,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Volume", "Disk Size", "Disk Space Used", "Percent Disk Space Used"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "Volume", index: "Volume", align: "center", width: "250px" },
                        { name: "DiskSize", index: "DiskSize", align: "center", width: "120px" },
                        { name: "DiskSpaceUsed", index: "DiskSpaceUsed", align: "center", width: "120px" },
                        { name: "PercentDiskSpaceUsed", index: "PercentDiskSpaceUsed", align: "center", width: "120px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (val.substr(0, val.length - 1) >= 90) return "style='background-color: red'"; if (val.substr(0, val.length - 1) < 90 && val.substr(0, val.length - 1) >= 80) return "style='background-color: yellow'"; } }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: false,
        caption: "设备磁盘使用情况"
    });

    $(gridAvailability).jqGrid({
        url: loadUrlAvailability,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "IP Address", "Average Availability"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "IP_Address", index: "IP_Address", align: "center", width: "120px" },
                        { name: "AvgAvailability", index: "AvgAvailability", align: "center", width: "120px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (val.substr(0, val.length - 1) <= 95) return "style='background-color: red'"; } }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: false,
        caption: "设备Availability"
    });

    $(gridCPUUsed).jqGrid({
        url: loadUrlCPUUsed,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Average CPU Load", "Peak CPU Load"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px" },
                        { name: "AvgLoad", index: "AvgLoad", align: "center", width: "120px" },
                        { name: "MaxLoad", index: "MaxLoad", align: "center", width: "120px", cellattr: function (rowId, val, rawObject, cm, rdata) { if (val.substr(0, val.length - 1) >= 90) return "style='background-color: red'"; } }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: false,
        caption: "设备CPU使用率"
    });

    $(gridDeviceNetwork).jqGrid({
        url: loadUrlDeviceNetwork,
        mtype: 'POST',
        datatype: "json",
        // 列名称
        colNames: ["Node", "Interface", "Average Receive bps", "Peak Receive bps", "Average Transmit bps", "Peak Transmit bps"],
        colModel: [
                        { name: "NodeName", index: "NodeName", align: "center", width: "150px", cellattr: deviceNetworkCellattr },
                        { name: "Interface", index: "Interface", align: "center", width: "400px", cellattr: deviceNetworkCellattr },
                        { name: "AvgReceive", index: "AvgReceive", align: "center", width: "100px", cellattr: deviceNetworkCellattr },
                        { name: "MaxReceive", index: "MaxReceive", align: "center", width: "100px", cellattr: deviceNetworkCellattr },
                        { name: "AvgTrans", index: "AvgTrans", align: "center", width: "100px", cellattr: deviceNetworkCellattr },
                        { name: "MaxTrans", index: "MaxTrans", align: "center", width: "100px", cellattr: deviceNetworkCellattr }
            ],
        height: "100%",
        rowNum: 500,
        sortable: true,
        sortname: "NodeName",
        sortorder: "desc",
        autowidth: false,
        gridModel: true,
        gridNames: true,
        hiddengrid: false,
        caption: "设备接口网络情况"
    });    
}    