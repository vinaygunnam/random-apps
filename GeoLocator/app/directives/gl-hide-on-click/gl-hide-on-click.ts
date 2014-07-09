module App.Directives {
    "use strict";

    interface IGlHideOnClickScope extends ng.IScope {
        triggerSelector: string;
        fade?: boolean;
    }

    class GlHideOnClickDescriptor {
        constructor() {
            var directive: ng.IDirective = {
                restrict: "A",
                scope: {
                    triggerSelector: "@",
                    fade: "=?"
                },
                link: (scope: IGlHideOnClickScope, element: ng.IAugmentedJQuery) => {
                    if (scope.triggerSelector) {
                        var btnTarget = element.find(scope.triggerSelector);
                        btnTarget.on("click", () => {
                            if (scope.fade) {
                                element.fadeOut();
                            } else {
                                element.hide();
                            }
                        });
                    }
                }
            };

            return directive;
        }
    }

    container.directive("glHideOnClick", GlHideOnClickDescriptor);
}