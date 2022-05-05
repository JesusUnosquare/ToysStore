function MainController(a) {
    this.name = 'Todd';
    //$scope.likes = ['pizza', 'coke'];
}

angular
    .module('app')
    .controller('MainController', [
        '$scope',
        MainController
    ]);