var MainController = function ($scope, $http)
{
    
    $scope.Distmodels = {
        Districts: [
                        { district_Id: "0", district_Name: "" }
                   ]    
    };

    //var HydrantLoc;

      $scope.getDistricts = function () {
          $http({method:'GET',url:'http://localhost:54303/api/District'}).success(function (response,status) {
              $scope.Districts = response;
              console.log($scope.Districts[0].district_Id);
              console.log($scope.Districts[0].district_Name);
              //console.log(response);
              $scope.Districts = response

              //$scope.selectedLocation = $scope.Districts[0];
        });

    };
   

      $scope.ChangeLocation = function (loc) {
          $http({ method: 'GET', url: 'http://localhost:54303/api/District/' + loc.district_Id }).success(function (response, status) {
              //$scope.Districts = response;
              //console.log($scope.Districts[0].district_Id);
              //console.log($scope.Districts[0].district_Name);
              
              $scope.HydrantLoc = response
            console.log($scope.HydrantLoc);
              //$scope.selectedLocation = $scope.Districts[0];

              $scope.selectedLocation = loc;

              
          });
          }
        
   
    $scope.getDistricts();


    //function($scope,$http){
    //    $http.jsonp("api/District").success(function(response){

    //    })
    //}
    //$scope.selectedLocation = $scope.Districts.district_Name[0];


    };
MainController.$inject = ['$scope','$http'];