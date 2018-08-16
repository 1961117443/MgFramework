///订单列表
var OrderList = {
    Init: function () {

        layui.use('table', function () {
            var table = layui.table;
            var dd = [];
            //第一个实例
            table.render({
                elem: '#gridList'
                , height: 'full-105'
                , limit: 30
                , limits: [10, 20, 30, 40, 50]
                , url: '/Order/Online/GetList'
                // , data: 'data/table.json'
                , page: true //开启分页
                , cols: [[ //表头
                    { field: 'Id', width: 200, sort: false, fixed: 'left', align: 'center', toolbar: '#barList' }
                    , { field: 'BillCode', title: '订单号', width: 130 }
                    , { field: 'OrderDate', title: '订单日期', width: 110, sort: false, unresize: true, templet: function (d) { return com.html_formatter.datetime(d.OrderDate); } }
                    , { field: 'CustomerID_Code', title: '客户编号', width: 100 }
                    , { field: 'CustomerID_Name', title: '客户名称', width: 120 }
                    , { field: 'CustomerPO', title: '客户PO', width: 120, sort: false }
                    , { field: 'AcceptDate', title: '预交日期', width: 110, sort: false, unresize: true, templet: function (d) { return com.html_formatter.datetime(d.AcceptDate); } }
                    , { field: 'AluminumPriceDate', title: '铝锭价日期', width: 110, sort: false, unresize: true, templet: function (d) { return com.html_formatter.datetime(d.AluminumPriceDate); } }
                    //, { field: 'PackingID_PackingName', title: '包装方式', width: 100, sort: false }
                    , { field: 'OrderType', title: '订单类型', width: 90, sort: false }
                    , { field: 'Project', title: '所属工程', width: 100, sort: false }
                    , { field: 'Maker', title: '制单人', width: 80, sort: false }
                    , { field: 'MakeDate', title: '制单日期', width: 160 }
                    , { field: 'Audit', title: '审核人', width: 80, sort: false }
                    , { field: 'AuditDate', title: '审核日期', width: 160 }
                    , { field: 'Remark', title: '备注', width: 150, sort: false }

                    //  <th lay-data="{fixed: 'right', width:178, align:'center', toolbar}"></th>
                ]]
            });
            //监听工具条
            table.on('tool(gridList)', function (obj) {
                var data = obj.data;
                if (obj.event === 'detail') {
                    OrderList.Events.Edit({ data: data, ds: 2 })
                } else if (obj.event === 'del') {
                    layer.confirm('真的删除行么', function (index) {
                        com.ajax({
                            type: "post", 
                            url: "/Order/Online/Delete/" + data.Id,
                            callback: function (d) {
                                if (d.s) {
                                    obj.del();
                                }
                            }
                        })
                        //obj.del();
                        //layer.close(index);
                    });
                } else if (obj.event === 'edit') {
                    OrderList.Events.Edit({ data: data, ds: 8 })
                } else if (obj.event === 'audit') {
                    layer.confirm('审核订单[' + data.BillCode + ']么', function (index) {
                        com.ajax({
                            type: "post",
                           url: "/Order/Online/Audit/" + data.Id,
                            callback: function (d) {
                                if (d.s) {
                                    OrderList.ReloadGrid();
                                }
                            }
                        }) 
                    });
                } else if (obj.event === 'unaudit') {
                    layer.confirm('反审订单[' + data.BillCode + ']么', function (index) {
                        com.ajax({
                            type: "post",
                            url: "/Order/Online/UnAudit/" + data.Id,
                            callback: function (d) {
                                if (d.s) { 
                                    OrderList.ReloadGrid();
                                }
                            }
                        })
                    });
                }
            });

            var $ = layui.$, active =
                {
                    reload: function () {
                        // var demoReload = "";// $('#demoReload').val();//获取输入框的值
                        //执行重载
                        table.reload('gridList',
                            {
                                /*page:
                                    {
                                        curr: 1 //重新从第 1 页开始
                                    }
                                , where: { name: demoReload }//这里传参  向后台
                                , */ url: '/Order/Online/GetList'//后台做模糊搜索接口路径
                                , method: 'get'
                            });
                    }
                };
            OrderList.ReloadGrid = function () {
                var type = "reload";// $(this).data('type');
                active[type] ? active[type].call(this) : '';
            };
        });
    },
    Events: {
        Add: function () {
            var i = com.ShowDialogBox({
                title: '新增订单',
                content: '/Order/Online/Create',
                end: function () { 
                    OrderList.ReloadGrid(); 
                }
            })
        },
        Edit: function (params) {
            var data = params.data;
            if (params.ds == undefined) {
                params.ds=2
            }
          //  console.log(params);
            if (data) {
                var i = com.ShowDialogBox({
                    title: '编辑订单[' + data.BillCode + ']',
                    content: '/Order/Online/Detail?id=' + data.Id + '&ds=' + params.ds,
                    end: function () {
                        if (params.ds == 2) {
                            return;
                        }
                        OrderList.ReloadGrid();
                       // layer.msg("解除[" + data.Id + "]的锁定！[" + i + "]");
                    }
                })
            }
        }
    }, 
    ReloadGrid: function () {}

};



///订单详情
var orderDetail = { 
    //刷新列表
    ReloadGrid: function () { }, 
    Events: {
        //选择客户
        ChooseCustomer: function () {
            com.ShowChooseDialog({
                title: '选择客户', 
                content: '/BaseData/Customer/Dialog',
            }, function (data) {
                if (data && data.length > 0) { 
                    $("#orderDetailForm input[name='CustomerID']").val(data[0].Id);
                    $("#orderDetailForm input[name='CustomerID_Code']").val(data[0].Code);
                    $("#orderDetailForm input[name='CustomerID_Name']").val(data[0].Name); 
                }
               
            });
        },
        //预览的单据转修改
        Edit: function (id) {
            com.ajax({
                url: '/Order/Online/CheckOrder?id=' + id+'&ds=8', 
            })
            //var params = obj.data;
            //var opt = {
            //    title: '编辑明细[' + params.SalesOrderTraceCode + ']'
            //    , content: '/Order/Online/EditItem?id=' + params.Id
            //    , end: function () {
            //        orderDetail.ReloadGrid();
            //    }
            //}
            //var r = com.ShowDialogBox(opt);
        }, 
        //修改明细
        EditItem: function (obj) {
            var params = obj.data;
            var opt = {
                title: '编辑明细[' + params.SalesOrderTraceCode + ']'
                , content: '/Order/Online/EditItem?id=' + params.Id
                , end: function () {
                    orderDetail.ReloadGrid();
                }
            }
            var r = com.ShowDialogBox(opt);
        }, 
        //保存订单
        Save: function (id) { 
            var param = $("#orderDetailForm").serialize();
            com.ajax({
                type: "post",
                data: param,
                url: "/Order/Online/Edit/" + id,
                callback: function (d) {
                    if (d.s) {
                        orderDetail.Events.Close();
                    }
                }
            });
        },
        //关闭窗体
        Close: function () {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        },
        //添加
        Append: function (id) {
            var opt = {
                title: '添加明细'
                , content: '/Order/Online/CreateItem'
                , end: function () {
                    orderDetail.ReloadGrid();
                }
            }
            var r = com.ShowDialogBox(opt);
        }
    },
    Init: function () {
        layui.use('laydate', function () {
            var laydate = layui.laydate;

            //执行一个laydate实例
            laydate.render({
                elem: '#AluminumPriceDate' //指定元素
            });

            //执行一个laydate实例
            laydate.render({
                elem: '#OrderDate' //指定元素
            });

            //执行一个laydate实例
            laydate.render({
                elem: '#AcceptDate' //指定元素
            });
        });

        layui.use('form', function () {
            var form = layui.form;
 
            if (orderDetail.model) { 
                var data = orderDetail.model.data;
                if (data) {
                    data.OrderDate = utils.formatDate(data.OrderDate);
                    data.AcceptDate = utils.formatDate(data.AcceptDate);
                    data.AluminumPriceDate = utils.formatDate(data.AluminumPriceDate);
                    form.val('orderDetailForm', data);
                } 
            } 
        });


        layui.use('table', function () {
            var table = layui.table;
            var dd = [];
            //第一个实例
            table.render({
                elem: '#gridDetailList'
                , height: 'full-400'
                //, limit: 100
                //, limits: [100, 200]
                //, page: true //开启分页
                , url: '/Order/Online/OrderItem'
                // , data: 'data/table.json'
                , cols: [[ //表头 
                      { field: 'Id', width: 150, sort: false, fixed: 'left', align: 'center', toolbar: '#barDetailList' }
                    , { field: 'SalesOrderTraceCode', title: '订单跟踪号', align: 'left', width: 180 }
                    , { field: 'SectionBarID_Code', title: '型材型号', align: 'left', width: 100 }
                    , { field: 'SectionBarID_Name', title: '型材名称', align: 'center', width: 120 }
                    , { field: 'TotalQuantity', title: '订单数', width: 80, align: 'right', sort: false }
                    , { field: 'OrderLength', title: '订单长度', align: 'right', width: 100, sort: false }
                    , { field: 'WallThickness', title: '壁厚', align: 'center', width: 80, sort: false }
                    , { field: 'FilmThickness', title: '膜厚', width: 60, align: 'center', sort: false }
                    , { field: 'TheoryMeter', title: '理论米重', width: 100, align: 'right', sort: false }
                    , { field: 'TheoryWeight', title: '理论重量', width: 100, align: 'right' }
                    , { field: 'SurfaceID_Name', title: '表面名称', align: 'center', width: 160 }
                    , { field: 'PackingID_PackingName', title: '包装方式', align: 'center', width: 160 }
                    , { field: 'OrderLevel', title: '订单等级', align: 'center', width: 100 }
                    , { field: 'Remark', title: '备注', align: 'center', width: 150, sort: false }
                ]]
            });
            //监听工具条
            table.on('tool(gridDetailList)', function (obj) {
                var data = obj.data;
                if (obj.event === 'copy') {
                    com.ajax({
                        type: "post",
                        url: "/Order/Online/CopyItem/" + data.Id,
                        callback: function (d) {
                            if (d.s) {
                                orderDetail.ReloadGrid();
                            }
                        }
                    });
                    //layer.msg('ID：' + data.Id + ' 的复制操作');
                } else if (obj.event === 'del') {
                    layer.confirm('真的删除行么', function (index) {
                        obj.del();
                        layer.close(index);
                    });
                } else if (obj.event === 'edit') {
                    orderDetail.Events.EditItem(obj);
                }
            });

            //搜索 ----------------------------------------------- Begin-----------------------------------------------------------
            var $ = layui.$, active =
                {
                    reload: function () {
                        // var demoReload = "";// $('#demoReload').val();//获取输入框的值
                        //执行重载
                        table.reload('gridDetailList',
                            {
                                /*page:
                                    {
                                        curr: 1 //重新从第 1 页开始
                                    }
                                , where: { name: demoReload }//这里传参  向后台
                                , */ url: '/Order/Online/OrderItem'//后台做模糊搜索接口路径
                                //, method: 'post'
                            });
                    }
                };
            orderDetail.ReloadGrid = function () {
                var type = "reload";// $(this).data('type');
                active[type] ? active[type].call(this) : '';
            };
            //搜索 ----------------------------------------------- End-----------------------------------------------------------

        });

        if (orderDetail.model) {
            if (orderDetail.model.DataState==2) {
                $('#orderDetailForm').find('input,textarea,select').attr('disabled', true);
                console.log($('table.layui-table thead tr th:eq(0)'));
                //$('table.layui-table thead tr th:eq(0)').addClass('layui-hide');
            }
        } 
    }
};



