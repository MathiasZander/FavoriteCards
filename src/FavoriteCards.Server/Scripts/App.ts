/// <reference path="declarations/Microsoft.JSInterop.d.ts" />

(window as any).FavoriteCards = {
    handleFileSelect(files: any) {
        var file = files[0];
        var reader = new FileReader();
        reader.onload = () => {
            DotNet.invokeMethodAsync('FavoriteCards.App', 'FileChanged', reader.result);
        };
        reader.readAsText(file);
    }
};

(window as any).LocalStorage = {
    SetItem(identifier: string, data: any) {
        localStorage.setItem(identifier, data);
        return true;
    },

    GetItem(identifier: string) {
        const result = localStorage.getItem(identifier);
        console.log(result);
        return result;
    },

    RemoveItem(identifier: string) {
        localStorage.removeItem(identifier);
        return true;
    },

    Clear() {
        localStorage.clear();
        return true;
    },

    Length(): number {
        return localStorage.length;
    },

    Key(index: number) {
        return localStorage.key(index);
    }
};