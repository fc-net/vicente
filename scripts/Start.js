Ext.onReady(function () {
    Ext.onReady(function () {
        var containerPanel = new Ext.Panel({ region: 'center' });
        var port = new Ext.Viewport({
            layout: 'border',
            clearContainerPanel:
                function () {
                    var f;
                    while (f = containerPanel.items.first()) {
                        containerPanel.remove(f, true);
                    }
                },
            items: [
            {
                region: 'north',
                html: '<h1 class="x-panel-header">Beesion recruitment</h1>',
                autoHeight: true,
                border: false,
                margins: '0 0 5 0'
            },
            {
                region: 'west',
                collapsible: true,
                title: 'Navigation',
                width: 200,
                layout: 'vbox',
                items:
                [
                    new Ext.Button({
                        text: 'Accesories',
                        iconCls: 'ImageAccesories',
                        height: 90,
                        width: 200,
                        handler:
                            function () {
                                port.clearContainerPanel();
                                var accesoriesGrid = new AccesoriesGrid();
                                containerPanel.add(accesoriesGrid);
                                containerPanel.doLayout();
                                BeesionRequest.ExecuteRecuest({
                                    maskElement: containerPanel,
                                    serviceName: 'AccesoriesService',
                                    operationName: 'GetAll',
                                    parameters: [],
                                    response:
                                        function (result) {
                                            accesoriesGrid.Load(result);
                                        }
                                });
                            }
                    }),
                    new Ext.Button({
                        text: 'Devices',
                        iconCls: 'ImageDevices',
                        height: 90,
                        width: 200,
                        handler:
                            function () {
                                port.clearContainerPanel();
                                var devicesGrid = new DevicesGrid();
                                containerPanel.add(devicesGrid);
                                containerPanel.doLayout();
                                BeesionRequest.ExecuteRecuest({
                                    maskElement: containerPanel,
                                    serviceName: 'DevicesService',
                                    operationName: 'GetAll',
                                    parameters: [],
                                    response:
                                        function (result) {
                                            devicesGrid.Load(result);
                                        }
                                });
                            }
                    }),
                    new Ext.Button({
                        text: 'Warehouses',
                        iconCls: 'ImageWarehouse',
                        height: 90,
                        width: 200,
                        handler:
                            function () {
                                Ext.Msg.alert('Message', 'Not implemented');
                            }
                    })
                ]
            },
            containerPanel]
        });
    });

});

