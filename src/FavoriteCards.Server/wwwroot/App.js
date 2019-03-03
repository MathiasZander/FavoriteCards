/// <reference path="declarations/Microsoft.JSInterop.d.ts" />
window.FavoriteCards = {
    handleFileSelect(files) {
        var file = files[0];
        var reader = new FileReader();
        reader.onload = () => {
            DotNet.invokeMethodAsync('FavoriteCards.App', 'FileChanged', reader.result);
        };
        reader.readAsText(file);
    }
};
window.LocalStorage = {
    SetItem(identifier, data) {
        localStorage.setItem(identifier, data);
        return true;
    },
    GetItem(identifier) {
        const result = localStorage.getItem(identifier);
        console.log(result);
        return result;
    },
    RemoveItem(identifier) {
        localStorage.removeItem(identifier);
        return true;
    },
    Clear() {
        localStorage.clear();
        return true;
    },
    Length() {
        return localStorage.length;
    },
    Key(index) {
        return localStorage.key(index);
    }
};
//# sourceMappingURL=App.js.map