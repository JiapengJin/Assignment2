// 按钮事件
var btnAct = {};
var search = {};
var SearchUser = {};

//弹框
var winObj = null;
var openType = '';
var chooseData = {};
var layer, table;
var reload;

layui.use(function () {
    table = layui.table;
    layer = layui.layer;



    //展示已知数据
    table.render({
        elem: '#demo',
        cols: [
            [ //标题栏
                {
                    field: 'ID',//对应的是数据库的字段
                    title: 'ID',//列表每列的标题
                    width: 80,
                    sort: true
                }, {
                    field: 'GoodName',
                    title: '商品名称',
                    width: 120
                }, {
                    field: 'Price',
                    title: '价格',
                    minWidth: 120,
                    sort: true
                }, {
                    field: 'Weight',
                    title: '重量',
                    minWidth: 120,
                    sort: true
                }, {
                    field: 'Color',
                    title: '颜色',
                    width: 80
                }, {
                    field: 'Brand',
                    title: '厂家',
                    width: 80
                }, {
                    field: "",
                    title: "",
                    width: 170,
                    templet: '#btn'
                }
            ]
        ],
        data: [],
        even: true,
        page: true, //是否显示分页
        limit: 10 //每页默认显示的数量
    });

    function open() {
        winObj = layer.open({
            type: 2,
            area: ['800px', '450px'],
            fixed: false, //不固定
            maxmin: true,
            content: 'http://localhost:55554/Home/GoodsDetail'
        });
    }

    search = function () {
        var searchCondition = $('#searchCondition').val();
        $.ajax({
            url: "/Home/GetGoodsList",
            data: {
                keyWord: searchCondition
            },
            success: function (res) {
                var data = JSON.parse(res);
                // 获取到 data
                table.reload('demo', {
                    data: data
                }, true)
            }
        });
    }

    SearchUser = function () {
        winObj = layer.open({
            type: 2,
            area: ['1000px', '500px'],
            fixed: false, //不固定
            maxmin: true,
            content: '/Home/UserList'
        });
    }



    reload = function () {
        // 此处调用查询接口
        $.ajax({
            url: "/Home/GetGoodsList",
            data: {
                keyWord: ""
            },
            success: function (res) {
                var data = JSON.parse(res);
                console.log(data);
                // 获取到 data
                table.reload('demo', {
                    data: data
                }, true)
            }
        });
    }

    btnAct = function (type, id) {
        openType = type;
        if (type == 'del') {
            layer.confirm('真的删除行么', function (index) {
                $.ajax({
                    url: "/Home/DelGoods",
                    data: {
                        ID: id
                    },
                    success: function (res) {
                        // 调用删除接口
                        reload();
                        layer.close(index);
                    }
                });
            });
            return
        }

        if (type == "SearchUser") {
            winObj = layer.open({
                type: 2,
                area: ['800px', '450px'],
                fixed: false, //不固定
                maxmin: true,
                content: '/Home/UserList'
            });
        }

        if (id) {
            // 此处调用 查询单条记录
            // $.ajax();
            // demo 写死
            //openType = type;
            $.ajax({
                url: "/Home/GetSingleGood",
                data: {
                    ID: id
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    chooseData = data;
                }
            });
        } else {
            chooseData = {};
        }
        open();
    }
    reload();

});