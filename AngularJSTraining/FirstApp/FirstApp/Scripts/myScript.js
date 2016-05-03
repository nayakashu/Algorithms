var employeeModule = angular.module("employeeModule", []);

var employeeController = function ($scope) {
    var employees = [
        { Name: 'Biswaranjan', Company: 'Emids Technologies' },
        { Name: 'Kanakdeepa', Company: 'US Technologies' },
        { Name: 'Ashutosh', Company: 'Microfocus Inc' },
    ];

    $scope.employees = employees;
};

employeeModule.controller("employeeController", employeeController);