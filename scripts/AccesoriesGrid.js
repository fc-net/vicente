AccesoriesGrid = Ext.extend(Ext.Panel, {
    constructor:
        function (config) {
            var grid = new Ext.grid.GridPanel({
                store: new Ext.data.JsonStore({
                    fields: ['Brand', 'PartNumber', 'Description'],
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
                        { header: 'ParNumber', dataIndex: 'PartNumber' },
                        { header: 'Description', dataIndex: 'Description', width: 380 },
                        {
                            header: 'Image', dataIndex: 'PartNumber', width: 120,
                            renderer:
                                function (value) { return '<img src="images/' + value + '.gif" />'; }
                        }
                    ]
                }),
                sm: new Ext.grid.RowSelectionModel({ singleSelect: true }),
                title: 'Accesories',
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
                            parameters: ['ACC', grid.getStore().getAt(rowIndex).data.PartNumber],
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
            AccesoriesGrid.superclass.constructor.call(this, config);
        }
});
Ext.reg('AccesoriesGrid', AccesoriesGrid);