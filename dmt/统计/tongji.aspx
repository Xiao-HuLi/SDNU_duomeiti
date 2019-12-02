<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tongji.aspx.cs" Inherits="EmptyProjectNet40_FineUI.统计.tongji" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html style="height: 100%">
   <head>
       <meta charset="utf-8">
   </head>
   <body style="height: 100%; margin: 0">
       <div id="container" style="height: 100%"></div>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts.min.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-gl/echarts-gl.min.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts-stat/ecStat.min.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/dataTool.min.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/china.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/map/js/world.js"></script>
       <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ZUONbpqGBsYGXNIYHicvbAbM"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/extension/bmap.min.js"></script>
       <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/simplex.js"></script>
       <script type="text/javascript">
           var dom = document.getElementById("container");
           var myChart = echarts.init(dom);
           var app = {};
           option = null;
           option = {
               title: {
                   text: '2018-2019-1学期 多媒体教室18周课程数据（仅供参考）',
                   subtext: '2018-2019-1学期 多媒体教室18周课程数据'
               },
               tooltip: {
                   trigger: 'axis'
               },
               legend: {
                   data: ['正常课程数据', '异常课程数据']
               },
               toolbox: {
                   show: true,
                   feature: {
                       dataZoom: {
                           yAxisIndex: 'none'
                       },
                       dataView: { readOnly: false },
                       magicType: { type: ['line', 'bar'] },
                       restore: {},
                       saveAsImage: {}
                   }
               },
               xAxis: {
                   type: 'category',
                   boundaryGap: false,
                   data: ['第1周', '第2周', '第3周', '第4周', '第5周', '第6周', '第7周']
               },
               yAxis: {
                   type: 'value',
                   axisLabel: {
                       formatter: '{value} 节课'
                   }
               },
               series: [
        {
            name: '正常课程数据',
            type: 'line',
            data: [1547, 1590, 1664, 1583, 1809, 1806, 1593],
            markPoint: {
                data: [
                    { type: 'max', name: '最大值' },
                    { type: 'min', name: '最小值' }
                ]
            },
            markLine: {
                data: [
                    { type: 'average', name: '平均值' }
                ]
            }
        },
        {
            name: '异常课程数据',
            type: 'line',
            data: [605, 559, 489, 413, 474, 443, 479],
            markPoint: {
                data: [
                    { name: '周最低', value: -2, xAxis: 1, yAxis: -1.5 }
                ]
            },
            markLine: {
                data: [
                    { type: 'average', name: '平均值' },
                    [{
                        symbol: 'none',
                        x: '90%',
                        yAxis: 'max'
                    }, {
                        symbol: 'circle',
                        label: {
                            normal: {
                                position: 'start',
                                formatter: '最大值'
                            }
                        },
                        type: 'max',
                        name: '最高点'
                    }]
                ]
            }
        }
    ]
           };
           ;


           if (option && typeof option === "object") {
               myChart.setOption(option, true);
           }
       </script>
   </body>
</html>
