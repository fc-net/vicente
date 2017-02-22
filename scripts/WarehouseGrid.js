WarehouseGrid = Ext.extend(Ext.Panel, {
    constructor:
        function (config) {
            var grid = new Ext.grid.GridPanel({
                store: new Ext.data.JsonStore({
                    fields: ['Name', 'ProductId', 'ProductType', 'Brand', 'Quantity', 'Description']
                    //groupField: 'Name'
                }),
                colModel: new Ext.grid.ColumnModel({
                    defaults: {
                        width: 120
                    },
                    //features: [{
                    //    ftype: 'grouping'
                    //}],
                    columns: [
                        { header: 'Name', dataIndex: 'Name' },
                        { header: 'ProductId', dataIndex: 'ProductId' },
                        { header: 'ProductType', dataIndex: 'ProductType' },
                        { header: 'Brand', dataIndex: 'Brand' },
                        { header: 'Quantity', dataIndex: 'Quantity' },
                        { header: 'Description', dataIndex: 'Description' }
                    ]
                }),
                sm: new Ext.grid.RowSelectionModel({ singleSelect: true }),
                title: 'Warehouse',
                layout: 'fit',
                autoHeight: true,
                enableColumnHide: false
            });

            config = Ext.apply({
                layout: 'fit',
                items: [grid],
                Load:
                    function (data) {
                        grid.getStore().loadData(data);
                    }
            }, config);
            WarehouseGrid.superclass.constructor.call(this, config);
        }
});
Ext.reg('WarehouseGrid', WarehouseGrid);