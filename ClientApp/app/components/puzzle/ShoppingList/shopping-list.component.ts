import { Component } from "@angular/core";

import { IListItem } from "./ListItem";

@Component({
    selector: "shopping-list",
    templateUrl: "./shopping-list.component.html"
})

export class ShoppingListComponent {
    listItems = new Array<IListItem>();
    selectedItem: IListItem;

    onItemAdded(item: IListItem) {
        this.listItems.push({
            name: item.name,
            amount: item.amount
        });
    }

    onSelect(item: IListItem) {
        console.log("Selected item ",item);
        this.selectedItem = item;
    }

    onRemove(item: IListItem) {
        this.listItems.splice(this.listItems.indexOf(item), 1);
        this.selectedItem = null;
    }
}