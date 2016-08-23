<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LifeBetter_Tree.aspx.cs" Inherits="BinaryTree.LifeBetter_Tree" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div>
        Mã cây :
        <asp:TextBox runat="server" ID="txtMA_CAY"></asp:TextBox>
        <input id="btnSHOW_TREE" type="submit" value="Show tree" />

    </div>




    <script type="text/javascript" src="Scripts/loader.js"></script>
    <script type="text/javascript">

        //google.charts.load('current', { packages: ["orgchart"] });
        //google.charts.setOnLoadCallback(drawChart1);


        $(document).ready(function () {
            ShowTree();
        });


        function ShowTree()
        {
            google.charts.load('current', { packages: ["orgchart"] });
            google.charts.setOnLoadCallback(drawChart1);
        }

        function drawChart1() {
            $.ajax({
                type: "POST",
                url: "LifeBetter_Tree.aspx/GetChartData",
                //data: '{}',
                data: '{ma_cay: "' + $("#<%=txtMA_CAY.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');


                    for (var i = 0; i < r.d.length; i++) {
                        var ma_cay = r.d[i][2].toString();                      
                        var memberName = r.d[i][4];
                        var ma_cay_tt = r.d[i][6] != null ? r.d[i][6].toString() : '';
                        var ma_goi_dau_tu = r.d[i][10];

                        data.addRows([[{
                            v: ma_cay,
                            f: memberName
                                + '<div>(<span style="color:red">'
                                + ma_cay
                                + '</span>)<div><img src = "Pictures/goi_' + ma_goi_dau_tu + '.png" "height="31" width="35" /></div>'
                        }, ma_cay_tt, memberName]]);
                    }
                    var chart = new google.visualization.OrgChart($("#chart")[0]);

                    chart.draw(data, { allowHtml: true, nodeClass: 'blf-orgchart-node', allowCollapse: true });
                },
                failure: function (r) {
                    //alert(r.d);
                },
                error: function (r) {
                    //alert(r.d);
                }
            });
        }
    </script>

    <div id="chart">
    </div>
</asp:Content>