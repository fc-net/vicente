BeesionRequest = {
    ExecuteRecuest:
        function (request) {
            // Mask
            var mask = null;
            if (request.maskElement) {
                var el = request.maskElement.getEl();
                if (el) {
                    mask = new Ext.LoadMask(el, { msg: 'Processing...' });
                    mask.show();
                }
            }
            
            // Parameters
            var encodedParams = { serviceName: request.serviceName, operationName: request.operationName };
            var i = 0;
            Ext.each(
                request.parameters,
                function (parameter) {
                    i++;
                    encodedParams['parameter' + i] = Ext.encode(parameter);
                },
                this
            );
            
            // Request
            Ext.Ajax.request({
                url: 'DefaultHandler.ashx',
                method: 'POST',
                params: encodedParams,
                timeout: request.timeout ? request.timeout : 60000,
                success:
                    function (rst, req) {
                        if(mask)
                            mask.hide();
                        var result = Ext.util.JSON.decode(rst.responseText);
                        request.response.call(request.scope, result);
                    },
                failure:
                    function (rst, req) {
                        if(mask)
                            mask.hide();
                        if (rst.isTimeout)
                            Ext.MessageBox.alert('Error', 'Timeout Expired');
                        else {
                            var btnOk = new Ext.Button({
                                text: 'Ok',
                                iconCls: 'ImageOk',
                                scope: this
                            });
                            var winException = new Ext.Window({
                                layout: 'fit',
                                title: 'Exception',
                                iconCls: 'ImageException',
                                html: rst.responseText,
                                width: 750,
                                height: 500,
                                autoScroll: true,
                                modal: true,
                                items: [],
                                bbar: new Ext.Toolbar({ items: ['->', btnOk] })
                            });
                            btnOk.on(
                                'click',
                                function () {
                                    winException.close();
                                },
                                this
                            );
                            winException.show();
                        }
                    }
            });
        }
}