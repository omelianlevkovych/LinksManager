(function (angular) {
    angular
        .module('linkModule')
        .factory('linkService', linkService);

    linkService.$inject = ['$http'];

    function linkService($http) {
        var service = {
            getLinks: getLinks,
            getLink: getLink,
            addLink: addLink,
            updateLink: updateLink,
            removeLink: removeLink
        };

        return service;

        function getLinks() {
            var promise = $http.get('/Link/GetLinks');
            return promise;
        };

        function getLink(link) {
            var promise = $http.get('Link/GetLink', link);
            return promise;
        };

        function addLink(link) {
            var promise = $http.post('Link/AddLink', link);
            return promise;
        };

        function updateLink(link) {
            var promise = $http.post('Link/UpdateLink', link);
            return promise;
        };

        function removeLink(link) {
            var promise = $http.post('Link/RemoveLink', link);
            return promise;
        }
    }
})(angular);
