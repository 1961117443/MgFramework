var onlineManager = { 
    ShowOrder: function (id) {
        layui.use('layer', function () {
            var layer = layui.layer;
            var index= layer.open({
                type: 2,
                title: '新增订单',
               // shade: [0.8, '#393D49'],
                maxmin: true,
                area: ['1024px', '800px'],
                content: '/Order/Online/Create',
                zIndex: layer.zIndex,
                success: function (layero) {
                    layer.setTop(layero);
                },
                end: function () {


                }
            }); 
           // layer.full(index);
        })
    },
    Init: function () {
        $('#masterGrid').datagrid({
            fit: false, border: true, singleSelect: true, rownumbers: true, remoteSort: false, cache: false, method: 'get', idField: 'Id',
            queryParams: { _t: com.settings.timestamp(), keyword: "" },
            pagination: true, pageList: [5, 10, 15, 20,  30, 50, 100], pageSize: 20,
            url: '/Order/Online/GetList',
            onLoadSuccess: function (data) {
                $("a[name='edit']").linkbutton({ text: '', plain: true, iconCls: 'bill-editor' });
                $("a[name='delete']").linkbutton({ text: '', plain: true, iconCls: 'bill-delete' });
                $("a[name='view']").linkbutton({ text: '', plain: true, iconCls: 'bill-browse' });
                $("a[name='audit']").linkbutton({ text: '', plain: true, iconCls: 'bill-audit' });
                $(this).datagrid('fixRowHeight');
            }, 
        });  
    },
    formatOper: function (v, r, i) {
        var html = ''; 
        html += "<a class=\"bill-search\" name='view'  href=\"javascript:void(0)\" onclick=\"onlineManager.Browse(1,'" + r.Id + "')\" title=\"查看\">查看</a>";
        //  if (item.Status == EAuditeJson.Wait || item.Status == EAuditeJson.NotPass) {
        html += "<a class=\"bill-edit\" name='edit' href=\"/Order/Online/Edit?id=" + r.Id + "\" >编辑</a>";
        // }
        html += "<a class=\"bill-remove\" name='delete'  href=\"javascript:void(0)\" onclick=\"onlineManager.Delete('" + r.Id + "');\" title=\"删除\">删除</a>";
        html += "<a class=\"bill-search\" name='audit'  href=\"javascript:void(0)\" onclick=\"onlineManager.Audite(1,'" + r.Id + "')\" title=\"审核\">审核</a>";

        // if (item.Status == EAuditeJson.Wait) {
        //     html += "<a class=\"icon-ok\" href=\"javascript:void(0)\" onclick=\"InStorageManager.Audite(2,'" + r.Id+ "')\" title=\"审核\"></a>&nbsp;&nbsp;";
        // }

        //html += "<a class=\"icon-print\" href=\"/Report/Manager/Show?ReportNum=" + ReprtNum + "&OrderNum=" + r.Id + "\" title=\"打印\"></a>&nbsp;&nbsp;"; 
        return html;
    },
    Search_Data: function (param) {
        var q = { _t: com.settings.timestamp()};
        if (param) { 
            q.keyword = JSON.stringify(param);
        }
        $('#masterGrid').datagrid('reload', q);
    },
    NewOrder: function () {
        
    },
    Browse: function (data) {

    },
    Audite: function (data) {

    },
    Delete: function (data) {

    },
    setPackData: function (data) {
        $('#PackingID_PackingName').textbox("setText", data.PackingName);
        $('#PackingID').val(data.Id); 
    },
    setCustomerData: function (data) {
        $('#CustomerID_Code').textbox("setText", data.Code);
        $('#CustomerID_Name').textbox("setText", data.Name);
        $('#CustomerID').val(data.Id); 
    },
};

var onlineEdit = {  
    LayerCreateItem: function () {
        layui.use('layer', function () {
            var layer = layui.layer;
            var index = layer.open({
                type: 2,
                title: '新增订单',
                maxmin: true,
                area: ['800px', '400px'],
                content: '/Order/Online/CreateItem',
                zIndex: layer.zIndex,
                success: function (layero) {
                    layer.setTop(layero);
                },
                end: function () {


                }
            });
            // layer.full(index);
        })
    },
    setPackData: function (data) { 
        $('#editForm #PackingID_PackingName').textbox("setValue", data.PackingName);
        $('#editForm #PackingID').textbox("setValue", data.Id); 
    },
    setSurfaceData: function (data) {
        $('#editForm #SurfaceID_Name').textbox("setValue", data.SurfaceName);
        $('#editForm #SurfaceID').textbox("setValue", data.Id);
    },
    setSectionBarData: function (data) {
        $('#editForm #SectionBarID_Name').textbox("setValue", data.Name);
        $('#editForm #SectionBarID_Code').textbox("setValue", data.Code);
        $('#editForm #WallThickness').textbox("setValue", data.WallThickness);
        $('#editForm #TheoryMeter').textbox("setValue", data.Theoreticalweight);
        $('#editForm #SectionBarID').textbox("setValue", data.Id);
    },
    Init: function () {
        $('#tabInfo').datagrid({
            fit: false, border: true, singleSelect: true, rownumbers: true, remoteSort: false, cache: false, method: 'get', idField: 'Id',
            showFooter: true,  
            //queryParams: { _t: com.settings.timestamp(), keyword: "" },
            //pagination: true, pageList: [5, 10, 15, 20, 30, 50, 100], pageSize: 30,
            url: '/Order/Online/OrderItem',
            onLoadSuccess: function (data) {
                $("a[name='edit']").linkbutton({ text: '', plain: true, iconCls: 'bill-editor' });
                $("a[name='delete']").linkbutton({ text: '', plain: true, iconCls: 'bill-delete' });
                $("a[name='copy']").linkbutton({ text: '', plain: true, iconCls: 'bill-copy' });
                $(this).datagrid('fixRowHeight');
            },
        });
        //$("#mainForm").formSerialize
    },
    formatOper: function (v, r, i) {
        if (v == "合计") {
            return v;
        } 
        var html = ''; 
        html += "<a class=\"bill-edit\" name='edit' href=\"javascript:void(0)\" onclick=\"onlineEdit.EditItem('" + r.Id + "')\" title=\"编辑\"></a>";
        html += "<a class=\"bill-remove\" name='delete' href=\"javascript:void(0)\" onclick=\"onlineEdit.DelItem('" + r.Id + "')\" title=\"删除\"></a>";
        html += "<a class=\"bill-copy\" name='copy' href=\"javascript:void(0)\" onclick=\"onlineEdit.CopyItem('" + r.Id + "')\" title=\"复制\"></a>";
        return html;
    },
    SaveChange: function (id) {
        //$("#mainForm").submit();
        var param = $("#mainForm").serialize();
        //console.info(param);
        com.ajax({
            type: "post",
            data: param,
            url: "/Order/Online/Edit/" + id, 
            success: function (result) {
                com.msg(result);
                if (result.s) { 
                    setTimeout(function () {
                        window.location.href = "/Order/Online/List";
                    }, 1000);
                }
               
                
            }
        }); 
    }, 
    ShowEditForm: function (param) { 
        var submit = function () { 
           // alert(param.url);
            var ff = $("#editForm").form('submit',
                {
                    url: param.url,
                    method: 'post',
                    onSubmit: function (sp) { 
                        
                        //alert("onSubmit");
                    },
                    success: function (data) {
                        data = eval("(" + data + ")");
                        if (data.s) {
                            onlineEdit.Reload();
                        }
                        //alert(1);

                       // p.dialog('close');
                    }
                });
            
            //ff.submit();
        };
        var defopt = {
            title: 'text',
            width: 800,
            height: 600,
            //href: param.url,
            iconCls: 'icon-save',
        };
        var p = com.dialog($.extend(defopt, param), submit); 
    },
    EditItem: function (id) {
        var data = {
            href: '/Order/Online/EditItem/' + id,
            title: '编辑'
        };
        onlineEdit.ShowEditForm(data);
    },
    CreateItem: function () {
        var data = {
            href: '/Order/Online/CreateItem/',
            title:'添加'
        }; 
        onlineEdit.ShowEditForm(data);
    },
    CopyItem: function (id) {
        //alert(id);
        com.ajax({
            url: "/Order/Online/CopyItem/" + id,
            type: "post",
            dataType: "json",
            success: function (result) {
                if (result.s) {
                    onlineEdit.Reload();
                }
            }
        });

    },
    DelItem: function (id) {
        com.ajax({
            url: "/Order/Online/DeleteItem/" + id,
            type: "post",
            dataType: "json",
            success: function (result) {
                if (result.s) {
                    onlineEdit.Reload();
                }
            }
        });
    },
    Reload: function () {
        $('#tabInfo').datagrid('reload');
    },
};



