import { Component, EventEmitter, Output } from "@angular/core";

import { IListItem } from "./ListItem";

@Component({
    selector: "shopping-list-new-item",
    templateUrl: "./shopping-list-new-item.component.html"
})

export class ShoppingListNewItemComponent {
    item = { name: '', amount: 0 };
    @Output() itemAdded = new EventEmitter<IListItem>();

    onClick() {
        this.itemAdded.emit(this.item);
    }
}