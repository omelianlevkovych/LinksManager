(function (angular) {
    angular
        .module('linkModule')
        .controller('linkController', LinkController);
    
    LinkController.$inject = ['linkService'];

    function LinkController(linkService) {
        
        var vm = this;
        vm.links = [];
        vm.newLinkTitle = "";
        vm.onAddNewLink = onAddNewLink;
        vm.removeLink = removeLink;

        init();

        function init() {
            var linkPromise = linkService.getLinks();
            linkPromise.then(function (response) {
                //for (var i = 0; i < response.data.length; ++i)
                //{
                //   response.data[i].CreationDate = ToJavaScriptDate(response.data[i].CreationDate);
                //}

                vm.links.push.apply(vm.links, JSON.parse(response.data));
            })

        };

        function onAddNewLink()
        { 
            var newLink ={ Title: vm.newLinkTitle };
            linkService
                .addLink(newLink)
                .success(function (response) {
                    //response.CreationDate = ToJavaScriptDate(response.CreationDate);
                    vm.links.push(JSON.parse(response));   
                    vm.newLinkTitle = "";
                });
        }

        function removeLink(link) {
            linkService
                .removeLink(link)
                .success(function (response) {
                    angular.forEach(vm.links, function (element, index) {
                        if (link.Id == element.Id) {
                            vm.links.splice(index, 1);
                        }
                    });
                });
        }

        //function ToJavaScriptDate(value) {
        //    var pattern = /Date\(([^)]+)\)/;
        //    var results = pattern.exec(value);
        //    var dt = new Date(parseFloat(results[1]));
        //    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
        //}

    };
})(angular);