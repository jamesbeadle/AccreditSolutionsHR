
app.controller("indexController", function ($scope, $location, $uibModal) {

    //employee model variables
    $scope.employee =
    {
        FirstName: '',
        LastName: '',
        Email: '',
        Dob: '',
        Department: '', 
        StatusId: 2,
        Status: { id: 2, label: 'Pending' },
        EmployeeNumber: ''
    };
    $scope.statuses = [];
    $scope.departments = [];

    //populate status values
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: "api/Statuses/GetStatuses"
    }).then(res =>
    {
        res.forEach(status =>
        {
            $scope.statuses.push(
                {
                    id: status.Id,
                    name: status.Name
            });
        });
    });

    //populate department values
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: "api/Departments/GetDepartments"
    }).then(res =>
    {
         res.forEach(department => {
            $scope.departments.push(
                {
                    id: department.Id,
                    name: department.Name
                });
         });
    });

    //populate employee values
    $scope.employees = [];/* $.ajax(
        {
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            url: "api/Employees/GetEmployees"
        });
        */

    $scope.addEmployee = function (id) {
        $uibModal.open({
            templateUrl: function() {
                return 'PL/employeeForm.html?id=' + id + '?' +new Date();
            },
            controller: "indexController",
            resolve:
            {
                departments: function () {
                    return $scope.departments;
                },
                statuses: function () {
                    return $scope.statuses;
                }
            }
        }).result.then(function () { }, function (res) { });
    };

    $scope.saveEmployee = function () {
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            url: "api/Employees/CreateEmployee",
            data: JSON.stringify($scope.employee)
        });
    };

    //set the default sort column for the employees table
    $scope.sortType = 'name';
    $scope.sortReverse = true;

});