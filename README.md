# 🕹️GDD Adventure
Professor Blake's GDD211-Lab3 Example Project

Use this project as a template for implimenting your own art, animation, level design, and narrative.

---
## 🎨[Art](#art)  •  🗡️[Quests](#quests)

# Art
There are several example art assets in the project:
- Tiles : The sprites which make up the level.
- Characters : There are a few simple pixel art characters with idle animations.
- Quest Items : Items which a player can find when on a Quest.

To **change** an art asset, simple save over the art asset in the Unity project. All art is currently 16px x 16px, though you should be able to use other resolutions.

To **add** an art asset:
- Tiles
  - ![s1](https://github.com/user-attachments/assets/e511accf-1efd-4075-b9f2-1f650371d61c)
  - Add your sprite to the project **Assets** folder.
  - In the Tiles Data folder `Assets > Game > Data > Tiles`, create a new Tile Data asset `Create > Data > Tile Data`. Name your asset.
  - Add your new sprite to the **Sprite** field on the Tile Data asset.
  - Select a **Tile Effect**.
  - Apply a **Color Tint** (optional).
  - ![s2](https://github.com/user-attachments/assets/fa1c1768-8702-4a3a-a7dc-3e3ebaba5030)
  - In the Tiles Prefab folder `Assets > Game > Prefabs > Tiles`, duplicate an existing Tile Prefab and change the **Tile Data** field of the **Tile** component to your new **Tile Data**.
  - In the scene hierarchy, add your new **Tile Prefab** to the **World Controller**'s Tile Prefabs list. Tiles will appear next to eachother in the scene, so move yours into a position that works for you.
---

# Quests
The Quest system allows you to design quests using only scriptable objects. 

To create a new quest:
- ![s4](https://github.com/user-attachments/assets/e8146af3-8304-4986-8903-eb9da2d49e87)
- In the Quest Data folder `Asests > Game > Data > Quests` make a new Quest Data asset `Create > Data > Quests > Quest Data`.
  - This asset contains the various **Quest Events** that make up the Quest. You can have as many Quest Events in a Quest as you like.
- Set the Name and Description fields for your Quest.
- Add text to the **Event Text** list to display text to the player when they first begin the quest.
- ![s5](https://github.com/user-attachments/assets/abd4b3ad-9e79-4d98-ac71-ec0623897a96)
- In the scene hierarchy, add your new **Quest Data** asset to the **Quest Trigger** GameObject's Quest Trigger component in the Quest Data field. Set the position on the map for this trigger to appear. The player will need to find this trigger to being the quest, so close to the middle of the map is best (0.5, 0.5).
- ![s6](https://github.com/user-attachments/assets/43a3f245-7439-4001-8a2c-34f89e352814)
- To add **Quest Events** to your Quest, create a new **GoToLocation** Quest Event `Create > Data > Quests > GoToLocation` This will create a trigger at the Quest Event position which will display the event text. This is currently the only quest type available.
- Fill in the details for the Quest Event. Choose the Sign or Trader trigger prefabs, or make your own.
- Add your Quest event to the **Quest**'s *Quest Event* list.

> [!NOTE]
> Quest Events will appear in the order they are listed inside the **Quest**'s *Quest Event* list. When an event is triggered, it will spawn the next trigger in the sequence.

> [!TIP]
> Set the **Event Type** of the final Quest Event in a Quest to **Complete Quest** to complete that Quest.
