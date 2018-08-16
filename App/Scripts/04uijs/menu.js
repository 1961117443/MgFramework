var menuManager = {
    Init: function () {
        $("#btn_add").linkbutton({
            onClick: function () {
                var submit = function (win) {
                    var obj = $(win).find("#mainForm").serialize();
                    com.ajax({
                        url: "/Sys/Menu/Edit",
                        data: obj
                    });
                };
                var defopt = {
                    title: '添加菜单',
                    width: 800,
                    height: 400, 
                    href:'/Sys/Menu/Create',
                    iconCls: 'icon-save',
                };
                var p = com.dialog(defopt, defopt, submit); 
            }
        });
        $('#masterGrid').treegrid({
            fit: false, border: true, singleSelect: true, rownumbers: true, remoteSort: false, cache: false, method: 'get',
            idField: 'Id', treeField: 'MenuName',   
            queryParams: { _t: com.settings.timestamp(), keyword: "" },
            url: '/Sys/Menu/GetList',
            onLoadSuccess: function (data) {
                $("a[name='edit']").linkbutton({ text: '', plain: true, iconCls: 'bill-editor' });
                $("a[name='delete']").linkbutton({ text: '', plain: true, iconCls: 'bill-delete' });
                //$("a[name='view']").linkbutton({ text: '', plain: true, iconCls: 'bill-browse' });
                //$("a[name='audit']").linkbutton({ text: '', plain: true, iconCls: 'bill-audit' });
                $(this).datagrid('fixRowHeight');
            },
        });  
    },
    formatOper: function (v, r, i) {
        var html = ''; 
        //  if (item.Status == EAuditeJson.Wait || item.Status == EAuditeJson.NotPass) {
        html += "<a class=\"bill-edit\" name='edit' href=\"/Sys/Menu/Edit?id=" + r.Id + "\" >编辑</a>";
        // }
        html += "<a class=\"bill-remove\" name='delete'  href=\"javascript:void(0)\" onclick=\"menuManager.Delete('" + r.Id + "');\" title=\"删除\">删除</a>"; 

        // if (item.Status == EAuditeJson.Wait) {
        //     html += "<a class=\"icon-ok\" href=\"javascript:void(0)\" onclick=\"InStorageManager.Audite(2,'" + r.Id+ "')\" title=\"审核\"></a>&nbsp;&nbsp;";
        // }

        //html += "<a class=\"icon-print\" href=\"/Report/Manager/Show?ReportNum=" + ReprtNum + "&OrderNum=" + r.Id + "\" title=\"打印\"></a>&nbsp;&nbsp;"; 
        return html;
    }
};

var menuEdit = {
    setData: function (data) {
        console.info(data);
    },
    Init: function () {
       
    },
};