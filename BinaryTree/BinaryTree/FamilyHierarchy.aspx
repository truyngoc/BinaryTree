<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FamilyHierarchy.aspx.cs" Inherits="BinaryTree.FamilyHierarchy" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>--%>


    <script type="text/javascript">
        //google.charts.load('current', { packages: ["orgchart"] });
        //google.charts.setOnLoadCallback(drawChart);

        //function drawChart() {
        //    var data = new google.visualization.DataTable();
        //    data.addColumn('string', 'Name');
        //    data.addColumn('string', 'Manager');
        //    data.addColumn('string', 'ToolTip');

        //    // For each orgchart box, provide the name, manager, and tooltip to show.
        //    data.addRows([
        //      [{ v: 'Mike', f: 'Mike<div style="color:red; font-style:italic">President</div>' },
        //       '', 'The President'],
        //      [{ v: 'Jim', f: 'Jim<div style="color:red; font-style:italic">Vice President</div>' },
        //       'Mike', 'VP'],
        //      ['Alice', 'Mike', ''],
        //      ['Bob', 'Jim', 'Bob Sponge'],
        //      ['Carol', 'Bob', '']
        //    ]);

        //    // Create the chart.
        //    var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
        //    // Draw the chart, setting the allowHtml option to true for the tooltips.
        //    chart.draw(data, { allowHtml: true });
        //}
    </script>

   <%-- <div id="chart_div"></div>--%>







    <script type="text/javascript" src="Scripts/loader.js"></script>

    <%--<script type="text/javascript">
        
        google.charts.load('current', { packages: ["orgchart"] });
        google.charts.setOnLoadCallback(drawChart1);

        
        function drawChart1() {
            $.ajax({
                type: "POST",
                url: "FamilyHierarchy.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');
                    for (var i = 0; i < r.d.length; i++) {
                        var memberId = r.d[i][0].toString();

                        var memberId_;
                        if (memberId > 9) memberId_ = 9; else memberId_ = memberId;     // them doan nay thu

                        var memberName = r.d[i][1];
                        var parentId = r.d[i][2] != null ? r.d[i][2].toString() : '';
                        data.addRows([[{
                            v: memberId,
                            f: memberName + '<div><img src = "Pictures/' + memberId_ + '.jpg" /></div>'
                        }, parentId, memberName]]);
                    }
                    var chart = new google.visualization.OrgChart($("#chart")[0]);
                    chart.draw(data, { allowHtml: true });
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>--%>



    <script type="text/javascript">

        google.charts.load('current', { packages: ["orgchart"] });
        google.charts.setOnLoadCallback(drawChart1);


        function drawChart1() {
            $.ajax({
                type: "POST",
                url: "FamilyHierarchy.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Entity');
                    data.addColumn('string', 'ParentEntity');
                    data.addColumn('string', 'ToolTip');


                    //1. Entity – This column stores the object of the Entity or Node in the Organization Chart. This object consists of two properties:-
                    //    a)     v – It stores the unique identifier of the Entity or Node. In this example, it is EmployeeId.
                    //    b)    f – It stores the formatting details of the Entity or Node. In this example, 
                    //            I have displayed EmployeeName on top, followed by Designation and finally the picture of the Employee.
                    //2. ParentEntity – This column stores the unique identifier of the ParentEntity 
                    //        i.e. ReportingManagerId. This is very important to find the parent of a particular Node. 
                    //          If left blank then the Node will be considered as Root Node.
                    //3. ToolTip – This column is used to bind ToolTip or Title attribute to the Node so that when the mouse is hovered, 
                    //      the default browser ToolTip is displayed. If you don’t want to display ToolTip leave it blank.

                    for (var i = 0; i < r.d.length; i++) {
                        var memberId = r.d[i][0].toString();

                        var memberId_;
                        var icon_type;
                        if (memberId > 9) icon_type = "goi_1"; else icon_type = "goi_5";     // them doan nay thu

                        var memberName = r.d[i][1];
                        var parentId = r.d[i][2] != null ? r.d[i][2].toString() : '';
                        data.addRows([[{
                            v: memberId,
                            //f: memberName + '<div><img src = "Pictures/' + memberId_ + '.jpg" /></div>'
                            f: memberName + '<div><img src = "Pictures/' + icon_type + '.png" "height="31" width="35" /></div>'
                        }, parentId, memberName]]);
                    }
                    var chart = new google.visualization.OrgChart($("#chart")[0]);


                    // su dung config option de thay doi style cho chart
                    // EX:
                    //var options = {
                    //    width: 400,
                    //    height: 240,
                    //    title: 'Toppings I Like On My Pizza',
                    //    colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                    //};

                    //chart.draw(data, options);
                    


                    chart.draw(data, { allowHtml: true, nodeClass: 'blf-orgchart-node', allowCollapse: true });
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <div id="chart">
    </div>





    <br />
    <br />
    <div>
        Your Name :
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <input id="btnGetTime" type="button" value="Show Current Time"
            onclick="ShowCurrentTime()" />
    </div>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        function ShowCurrentTime() {
            $.ajax({
                type: "POST",
                url: "FamilyHierarchy.aspx/GetCurrentTime",
                data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
        }
    </script>



    
</asp:Content>
