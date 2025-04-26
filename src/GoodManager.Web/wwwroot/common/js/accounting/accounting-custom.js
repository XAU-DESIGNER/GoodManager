async function getLastYearCostsAndIncomeAsChart(selectorId) {
    const selector = $(`#${selectorId}`);

    let costs = selector.data("costs");
    let income = selector.data("income");

    await initCostsAndIncomeChart(costs, income, selectorId);
}

async function initCostsAndIncomeChart(costs, income, selectorId) {
    let options = {
        colors: ["#0EA5E9", "#ff5724"],
        series: [{
            name: "درآمد",
            data: income
        }, {
            name: "هزینه",
            data: costs
        }],
        chart: {
            parentHeightOffset: 0,
            fontFamily: 'IRANSans, Tahoma, sans-serif',
            height: 249,
            type: "area",
            toolbar: {
                show: !1
            }
        },
        fill: {
            type: "gradient",
            gradient: {
                shadeIntensity: 1,
                inverseColors: !1,
                opacityFrom: .35,
                opacityTo: .05,
                stops: [20, 100, 100, 100]
            }
        },
        dataLabels: {
            enabled: !1
        },
        stroke: {
            width: 2,
            curve: "smooth"
        },
        plotOptions: {
            bar: {
                borderRadius: 5,
                barHeight: "90%",
                columnWidth: "40%"
            }
        },
        legend: {
            show: !1
        },
        xaxis: {
            categories: getAllYearMonthsName()
        },
        yaxis: {
            labels: {
                offsetX: -12,
                offsetY: 0,
                formatter: function (value) {
                    return value.toLocaleString('en-US');
                }
            }
        },
        grid: {
            padding: {
                left: 0,
                right: 0,
                top: -10,
                bottom: 8
            }
        },
        tooltip: {
            y: {
                formatter: function (value) {
                    return value.toLocaleString('en-US');
                }
            }

        }
    }
    let chart = new ApexCharts(document.querySelector(`#${selectorId}`), options);

    chart.render();
}