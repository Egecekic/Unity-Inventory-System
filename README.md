# Unity-Inventory-System

This system work with [this](https://github.com/Egecekic/Game-Save-Load-System).

Unity Package Manager dan InputSystem indirmeniz gerekiyor

[Inventory File](https://github.com/Egecekic/Unity-Inventory-System/tree/main/Inventory)
-------------------
[offset](https://github.com/Egecekic/Unity-Inventory-System/blob/main/Inventory/Inventory%20Holder.cs) oyuncunun hotbarının uzunluğunu belirlemek için kullanılıyor.
- Boş bir canvas ögesi olusturup kaç adet slottan olusacaksa olusacak prefapları chield olarak ekleyin
- Boş ögeyi fotoğraftaki gibi dolduru.

<p align="center">
  <img  src="https://user-images.githubusercontent.com/45740020/229564434-49d75e19-ce33-4e5e-8ef4-1b94949e3381.png">
</p>


[Iteam File](https://github.com/Egecekic/Unity-Inventory-System/tree/main/Iteam).
-------------------
- Itemlar ScriptableObject obje olarak kullanılacak.

- Itemlar InventoryIteamData den türetilmiş sekilde kullanılması daha iyi olur .

### Item yarıtılısı:
Project Dosyasında sağ tıklayıp , create sayfasından en üste yer alan Inventory System den EdibleItemData yaratıyoruz ve değerleri dolduyoruz

   ![ezgif com-video-to-gif](https://user-images.githubusercontent.com/45740020/229563005-3f021f72-ebbf-463c-b325-9bf12e833188.gif)

Bir gameobjesine PickUp Scriptini ekliyoruz PickUp scriptin de Iteam Data ya yaradığımız iteamı atıyoruz ve artık bir inventory iteamınız var

![ezgif com-video-to-gif (1)](https://user-images.githubusercontent.com/45740020/229563412-fe1c9038-7cb8-4ef5-b748-2deb58f5dcd4.gif)

Eğer save load sistemini kullanıyorsanız database scriptinden id ataması yapmanız gerekmete yoksa oyun sahnesinde olan itemleri kaydetmeli

[UI File](https://github.com/Egecekic/Unity-Inventory-System/tree/main/UI)
-------------------

### DynamicInventorySystem 
- Sistemin bu seklinde sırt çantasını görmek için kullanılıyor(farklı seyleri adepte etmeniz gerek), sırt çantasını görmek için boş bir canvan ögesi oluşturup altaki görüntüde ki gibi doldurun.
- Oyuncunun backpaci ve sandık gibi farklı envanter sistemi için kullanılacak
<p align="center">
  <img  src="https://user-images.githubusercontent.com/45740020/229568607-b133a3cf-6b53-41c2-bf5e-2ee71fef3987.png">
</p>

- SlotPrefap değişkenine verilen prefapı InventoryHolder da verilen inventorySize değiri kadar çoğaltıp size ui verir
  - SlotPrefapı içeriği
   - Parent da [InventorySlot_UI](https://github.com/Egecekic/Unity-Inventory-System/blob/main/UI/InventorySlot_UI.cs) scripti olucak 
   - Iteam Sprite ilk Image olucak
   - Slot Highlight sizin belirlediğiniz bir çerçeve olabalir (kullanımı size kalmıştır)
   - Iteam Count TextTmp oluca


<p align="center">
  <img  src="https://user-images.githubusercontent.com/45740020/229564997-762b7c31-1d8c-49b2-9b9d-d7b5489a7130.png">
</p>


### HotbarDisplay

```
    private int _maxIndexSize = 3;
    private int _currnetIndex= 0;
```
indexler verilen offset değeri unuluğunda olmalı

sadasdasf
sdafasdf
