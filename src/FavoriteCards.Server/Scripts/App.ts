/// <reference path="declarations/Microsoft.JSInterop.d.ts" />

(window as any).FavoriteCards = {
    handleFileSelect(files: any) {
        var method = {
            type: { assembly: 'FavoriteCards.App', name: 'FavoriteCards.App.Pages.ImportModel' },
            method: { name: 'FileChanged' }
        };

        var file = files[0];
        var reader = new FileReader();
        reader.onload = () => {
            DotNet.invokeMethodAsync('FavoriteCards.App', 'FileChanged', reader.result);
        };
        reader.readAsText(file);
    }
};





