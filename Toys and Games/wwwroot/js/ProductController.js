function ProductController($scope, $http) {
    var ctrl = this;
    var API = "https://localhost:7233/Product/";
    //Local properties
    this.Form = 1;
    ctrl.ProductList = {};
    ctrl.UpdateProd = {};
    $scope.newName = "";
    $scope.newDescription="";
    $scope.newCompany= "";
    $scope.newAgeRestriction= 0;
    $scope.newPrice= 0;
    $scope.newImageLink = "";
    getdata();
   
    function getdata() {
        $http.get(API + "All")
        .then(function (response) {
            console.log(response);
            ctrl.ProductList = response.data;
            console.log(ctrl.ProductList);
        })
    };

    this.showAddFormF = function () {
        this.Form = 2;
        this.newName = "";
        this.newDescription = "";
        this.newCompany = "";
        this.newAgeRestriction = 0;
        this.newPrice = 0;
        this.newImageLink = "";
    };
    this.showMainFormF = function () {
        this.Form = 1;
    };
    this.showUpdateFormF = function (item) {
        this.Form = 3;
        ctrl.UpdateProd = item;
    };

    
    this.addProduct = function (NameL,DescriptionL,AgeR,PriceL,CompanyL,Image) {
        console.log(JSON.stringify({
            Name: NameL,
            Description: DescriptionL,
            Company: CompanyL,
            AgeRestriction: AgeR,
            Price: PriceL,
            ImageLink: Image
        }));
        $http.post(API, JSON.stringify({
            Name: NameL,
            Description: DescriptionL,
            Company: CompanyL,
            AgeRestriction: AgeR,
            Price: PriceL,
            ImageLink: Image
        }))
            .then(function (response) {
                console.log(response);
                ctrl.Form = 1;
                getdata();
            }, function (response) {
                console.log("Error: " + response);
            });
    }
    this.updateProduct = function (IdL,NameL, DescriptionL, AgeR, PriceL, CompanyL, Image) {
        console.log(JSON.stringify({
            Id: IdL,
            Name: NameL,
            Description: DescriptionL,
            Company: CompanyL,
            AgeRestriction: AgeR,
            Price: PriceL,
            ImageLink: Image
        }));
      
        $http.put(API, JSON.stringify({
            Id: IdL,
            Name: NameL,
            Description: DescriptionL,
            Company: CompanyL,
            AgeRestriction: AgeR,
            Price: PriceL,
            ImageLink: Image
        }))
            .then(function (response) {
                console.log(response);
                ctrl.Form = 1;
                getdata();
            }, function (response) {
                console.log("Error: " + response);
            });
    }
    this.deleteProduct = function (IdL, Index, NameL) {
        if (confirm("Are you sure to delete this product? Product: " + NameL)) {
            console.log("Implement delete functionality here");
            $http.delete(API + IdL)
                .then(function (response) {
                    console.log(response);
                    ctrl.ProductList.splice(Index,1);
                }, function (response) {
                    console.log("Error: " + response);
                });
        }
    }
}
angular
    .module('app')
    .controller('ProductController',['$scope','$http', ProductController]);