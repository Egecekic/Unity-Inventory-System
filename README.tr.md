# Unity Envanter Sistemi

Unity için kaydetme/yükleme sistemiyle birlikte çalışan, basit ve modüler bir envanter sistemidir. Hotbar, dinamik envanter (sırt çantası, sandık vb.) ve ScriptableObject tabanlı eşyalar içerir.

> 🇬🇧 For English documentation, see [README.md](README.md).

## Özellikler

- ScriptableObject tabanlı eşya tanımları (kolay oluşturulur ve genişletilir)
- Uzunluğu ayarlanabilir hotbar
- Sırt çantası, sandık ve benzeri kaplar için dinamik envanter arayüzü
- Herhangi bir GameObject'i toplanabilir eşyaya çeviren PickUp bileşeni
- [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System) ile kaydetme/yükleme entegrasyonu

## Gereksinimler

- Unity (önerilen: güncel bir LTS sürümü)
- **Input System** paketi (*Window > Package Manager* üzerinden kurulur)
- **TextMeshPro** (eşya adedi yazısı için kullanılır)
- [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System) (yalnızca kaydetme/yükleme istiyorsanız)

## Proje Yapısı

| Klasör / Dosya | Açıklama |
| --- | --- |
| `Inventory/` | Temel envanter mantığı, `Inventory Holder` dahil |
| `Iteam/` | Eşya verileri (ScriptableObject), örn. `InventoryIteamData`, `EdibleItemData` |
| `UI/` | Envanter ve hotbar arayüz scriptleri, örn. `InventorySlot_UI`, `DynamicInventorySystem`, `HotbarDisplay` |
| `PickUp.cs` | Bir GameObject'i toplanabilir yapar ve bir eşyaya bağlar |

## Başlangıç

1. Depo içeriğini Unity projenizin `Assets` klasörüne kopyalayın.
2. Package Manager'dan **Input System** paketini indirin.
3. Aşağıdaki kurulum adımlarını izleyin.

## Kurulum

### 1. Hotbar

`Inventory Holder` içindeki `offset` değeri, oyuncunun hotbar uzunluğunu belirler.

1. Boş bir Canvas nesnesi oluşturun.
2. Kaç slottan oluşacaksa o kadar slot prefabını çocuk (child) olarak ekleyin.
3. Boş nesnenin referanslarını aşağıdaki örnek görseldeki gibi doldurun.

![Örnek hotbar](https://user-images.githubusercontent.com/45740020/229564434-49d75e19-ce33-4e5e-8ef4-1b94949e3381.png)

#### HotbarDisplay

```csharp
private int _maxIndexSize = 3;
private int _currentIndex = 0;
```

İndeks değerleri, `Inventory Holder` içinde verdiğiniz `offset` değeriyle uyumlu olmalıdır.

### 2. Eşya Oluşturma

Eşyalar ScriptableObject olarak kullanılır. Eşyalarınızı `InventoryIteamData` sınıfından türetmeniz önerilir.

1. Project penceresinde sağ tıklayıp **Create** menüsünü açın.
2. En üstte yer alan **Inventory System** bölümünden **EdibleItemData** seçin.
3. Eşyanın değerlerini doldurun.

![Eşya oluşturma](https://user-images.githubusercontent.com/45740020/229563005-3f021f72-ebbf-463c-b325-9bf12e833188.gif)

### 3. Eşyayı Toplanabilir Yapma

1. Bir GameObject'e `PickUp` scriptini ekleyin.
2. Oluşturduğunuz eşyayı `PickUp` scriptindeki **Item Data** alanına atayın.

Artık o nesne bir envanter eşyasıdır.

![PickUp kullanımı](https://user-images.githubusercontent.com/45740020/229563412-fe1c9038-7cb8-4ef5-b748-2deb58f5dcd4.gif)

> **Kaydetme/yükleme sistemini kullanıyor musunuz?** Database scripti üzerinden eşyalara ID ataması yapmanız gerekir. Aksi halde yalnızca oyun sahnesinde bulunan eşyalar kaydedilir.

### 4. Dinamik Envanter (Sırt Çantası / Sandık)

`DynamicInventorySystem`, sırt çantası ve sandık gibi farklı envanterleri göstermek için kullanılır. Kendi ihtiyaçlarınıza göre uyarlamanız gerekebilir.

1. Boş bir Canvas nesnesi oluşturun.
2. Referanslarını aşağıdaki görseldeki gibi doldurun.

![Dinamik envanter kurulumu](https://user-images.githubusercontent.com/45740020/229568607-b133a3cf-6b53-41c2-bf5e-2ee71fef3987.png)

**Slot Prefab** alanına verilen prefab, `InventoryHolder` içindeki `inventorySize` değeri kadar çoğaltılarak envanter arayüzünü oluşturur.

#### Slot Prefab İçeriği

- Ana nesnede [`InventorySlot_UI`](UI/InventorySlot_UI.cs) scripti bulunmalıdır.
- İlk `Image`, **eşya görseli (sprite)** olmalıdır.
- **Slot Highlight**, istediğiniz bir çerçeve olabilir (kullanımı size kalmıştır).
- **Item Count**, bir `TextMeshPro` yazısı olmalıdır.

![Slot prefab](https://user-images.githubusercontent.com/45740020/229564997-762b7c31-1d8c-49b2-9b9d-d7b5489a7130.png)

## İlgili Projeler

- [Game-Save-Load-System](https://github.com/Egecekic/Game-Save-Load-System) — bu envanterin birlikte çalışacak şekilde tasarlandığı kaydetme/yükleme sistemi.

## Katkıda Bulunma

Issue ve pull request'ler memnuniyetle karşılanır.

## Lisans

Henüz bir lisans belirtilmemiş. Başkalarının projeyi kullanabilmesi için bir `LICENSE` dosyası (örneğin MIT) ekleyin.
