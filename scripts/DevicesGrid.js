DevicesGrid = Ext.extend(Ext.Panel, {
    constructor:
        function (config) {
            var grid = new Ext.grid.GridPanel({
                store: new Ext.data.JsonStore({
                    fields: ['Brand', 'Model', 'Sku', 'Description'],
                    autoLoad: false
                }),
                colModel: new Ext.grid.ColumnModel({
                    defaults: {
                        width: 120,
                        sortable: false,
                        hideable: false
                    },
                    columns: [
                        { header: 'Brand', dataIndex: 'Brand' },
                        { header: 'Model', dataIndex: 'Model' },
                        { header: 'Description', dataIndex: 'Description', width: 380 },
                        {
                            header: 'Image', dataIndex: 'Sku', width: 120,
                            renderer:
                                function (value) { return '<img src="images/' + value + '.jpg" />'; }
                        }
                    ]
                }),
                sm: new Ext.grid.RowSelectionModel({ singleSelect: true }),
                title: 'Devices',
                layout: 'fit',
                autoHeight: true,
                enableColumnHide: false
            });

            grid.on({
                celldblclick:
                    function (scope, rowIndex, columnIndex, e) {

                        BeesionRequest.ExecuteRecuest({
                            maskElement: grid,
                            serviceName: 'StockService',
                            operationName: 'GetStockReport',
                            parameters: ['DEV', grid.getStore().getAt(rowIndex).data.Sku],
                            response:
                                function (result) {
                                    if (parseInt(result.TotalQuantity) > 0)
                                        Ext.Msg.alert('Status',
                                        'Total Count: ' + result.TotalQuantity + '</br>' +
                                        'Min Count: ' + result.MinStock + '</br>' +
                                        'Max Count: ' + result.MaxStock + '</br>' +
                                        'Average: ' + parseFloat(result.AverageStock).toFixed(2) + '</br>'
                                        );
                                    else
                                        Ext.Msg.alert('Status', result.Message);
                                }
                        });
                    }
            });
            config = Ext.apply({
                layout: 'fit',
                items: [grid],
                Load:
                    function (data) {
                        grid.getStore().loadData(data);
                    }
            }, config);
            DevicesGrid.superclass.constructor.call(this, config);
        }
});
Ext.reg('DevicesGrid', DevicesGrid);