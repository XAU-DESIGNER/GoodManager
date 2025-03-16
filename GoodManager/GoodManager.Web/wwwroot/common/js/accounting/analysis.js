//pie - charts

$(async function () {
    var options = {
        colors: ["#4ade80", "#f43f5e", "#a855f7"],
        series: [44, 55, 67],
        chart: {
            height: 350,
            type: "radialBar"
        },
        plotOptions: {
            radialBar: {
                hollow: {
                    margin: 15,
                    size: "35%"
                },
                track: {
                    margin: 15
                },
                dataLabels: {
                    name: {
                        fontSize: "22px"
                    },
                    value: {
                        fontSize: "16px"
                    },
                    total: {
                        show: !0,
                        label: "جمع کل",
                        formatter: function (e) {
                            return e.config.series.reduce((function (e, t) {
                                return e + t
                            }
                            ))
                        }
                    }
                }
            }
        },
        stroke: {
            lineCap: "round"
        },
        labels: ["Apples", "Oranges", "Bananas"]
    };


    var chart = new ApexCharts(document.querySelector("#pie-charts"), options);
    chart.render();
})

async function getUserIncomeAndExpenses() {
    await $.ajax({
        url: '/accounting/UserIncomeAndExpenses',
        type: 'POST',
        success: async function (result) {
            console.log(result);
        },
        error: async function () {
            console.log("failed");
        }
    })
}