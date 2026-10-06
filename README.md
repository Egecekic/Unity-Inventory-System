# Unity Inventory System

A simple, modular inventory system for Unity that works together with a save/load system. It includes a hotbar, a dynamic inventory (backpack, chests, etc.) and ScriptableObject-based items.

> 🇹🇷 Türkçe dokümantasyon için [README.tr.md](README.tr.md) dosyasına bakın.

## Features

- ScriptableObject-based item definitions (easy to create and extend)
- Hotbar with configurable length
- Dynamic inventory UI for backpacks, chests and other containers
- Pick-up component to turn any GameObject into a collectable item
- Save/load integration through [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System)

## Requirements

- Unity (recommended: a recent LTS version)
- **Input System** package (install via *Window > Package Manager*)
- **TextMeshPro** (used for item count text)
- [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System) (only if you want save/load support)

## Project Structure

| Folder / File | Description |
| --- | --- |
| `Inventory/` | Core inventory logic, including `Inventory Holder` |
| `Iteam/` | Item data (ScriptableObjects), e.g. `InventoryIteamData`, `EdibleItemData` |
| `UI/` | Inventory and hotbar UI scripts, e.g. `InventorySlot_UI`, `DynamicInventorySystem`, `HotbarDisplay` |
| `PickUp.cs` | Makes a GameObject collectable and links it to an item |

## Getting Started

1. Copy the repository contents into your Unity project's `Assets` folder.
2. Install the **Input System** package from the Package Manager.
3. Follow the setup steps below.

## Setup

### 1. Hotbar

The `offset` value in `Inventory Holder` defines the length of the player's hotbar.

1. Create an empty Canvas object.
2. Add as many slot prefabs as you want as children (one per hotbar slot).
3. Fill in the empty object's references as shown in the example image below.

![Example hotbar](https://user-images.githubusercontent.com/45740020/229564434-49d75e19-ce33-4e5e-8ef4-1b94949e3381.png)

#### HotbarDisplay

```csharp
private int _maxIndexSize = 3;
private int _currentIndex = 0;
```

The index values must match the `offset` value you set in `Inventory Holder`.

### 2. Creating Items

Items are used as ScriptableObjects. It is recommended to derive your items from `InventoryIteamData`.

1. In the Project window, right-click and open the **Create** menu.
2. Choose **Inventory System** (at the top of the list) and select **EdibleItemData**.
3. Fill in the item's values.

![Creating an item](https://user-images.githubusercontent.com/45740020/229563005-3f021f72-ebbf-463c-b325-9bf12e833188.gif)

### 3. Making an Item Collectable

1. Add the `PickUp` script to a GameObject.
2. Assign the item you created to the **Item Data** field of the `PickUp` script.

The GameObject is now an inventory item.

![Using PickUp](https://user-images.githubusercontent.com/45740020/229563412-fe1c9038-7cb8-4ef5-b748-2deb58f5dcd4.gif)

> **Using the save/load system?** You need to assign IDs to your items through the database script. Otherwise, only the items present in the game scene will be saved.

### 4. Dynamic Inventory (Backpack / Chest)

`DynamicInventorySystem` is used to display backpacks and other containers such as chests. You may need to adapt it to your own needs.

1. Create an empty Canvas object.
2. Fill in its references as shown in the image below.

![Dynamic inventory setup](https://user-images.githubusercontent.com/45740020/229568607-b133a3cf-6b53-41c2-bf5e-2ee71fef3987.png)

The prefab assigned to the **Slot Prefab** field is duplicated as many times as the `inventorySize` value in `InventoryHolder`, creating the inventory UI.

#### Slot Prefab Contents

- The parent has the [`InventorySlot_UI`](UI/InventorySlot_UI.cs) script.
- The first `Image` is the **item sprite**.
- **Slot Highlight** can be any frame or border you like (how you use it is up to you).
- **Item Count** is a `TextMeshPro` text.

![Slot prefab](https://user-images.githubusercontent.com/45740020/229564997-762b7c31-1d8c-49b2-9b9d-d7b5489a7130.png)

## Related Projects

- [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System) — the save/load system this inventory is designed to work with.

## Contributing

Issues and pull requests are welcome.

## License

No license has been specified yet. Add a `LICENSE` file (for example MIT) to let others use this project.
