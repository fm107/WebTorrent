import { Component, Input, Output, EventEmitter } from "@angular/core";

import { IListItem } from "./ListItem";

@Component({
    selector: "shopping-list-item",
    templateUrl: "./shopping-list-item.component.html"
})

export class ShoppingListItemComponent {
    @Input() shopItem: IListItem;
    @Output() itemRemoved = new EventEmitter<IListItem>();

    onDelete() {
        this.itemRemoved.emit(this.shopItem);
    }
}