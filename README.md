2D 橫向動作遊戲

專案定位

以角色操作與戰鬥回饋為核心的 2D 動作遊戲，重點在於角色控制與戰鬥系統的實作與結構拆分。

透過模組化設計，使角色行為可擴展與調整，而非集中於單一腳本中。


負責內容

建立玩家角色控制系統（移動、跳躍、攻擊）
設計攻擊判定與傷害處理流程
實作基礎敵人 AI 行為
建立角色動畫狀態機


系統設計重點

將「輸入」、「角色狀態」、「動畫」分離管理，降低耦合
使用有限狀態機（Idle / Move / Attack）簡化行為邏輯
透過 ScriptableObject 設計可擴展的狀態機架構，使戰鬥派生系統可動態調整與擴充


使用技術

Unity Animation

Rigidbody2D 物理系統

可擴展有限狀態機（FSM）設計


角色移動采用狀態機
![image](https://github.com/user-attachments/assets/4829c552-0b6b-4dbe-80a4-40b6b4820ea1)

實機畫面

基本左右移動

![001](https://github.com/user-attachments/assets/e6b868ec-fef1-4032-a912-1cbb5758037a)

2段跳

![002](https://github.com/user-attachments/assets/19ac03b6-a841-4fad-a800-5e59bf6dcfe9)

大跳

![003](https://github.com/user-attachments/assets/8f39960a-149c-44d9-88a4-f670f60e3236)

小跳

![004](https://github.com/user-attachments/assets/a85c0756-754c-433c-8fd0-c7505788175d)

浮板

![005](https://github.com/user-attachments/assets/48ff38ec-d097-432c-82b9-e6b593e76f9c)

角色射擊

![006](https://github.com/user-attachments/assets/e41c6caa-ca9e-4361-a540-a23b33aa9de5)

射擊扣除血量

![007](https://github.com/user-attachments/assets/c508b9fb-dac9-4eab-907c-ba75eca59af2)

死亡動畫並播放音效

![008](https://github.com/user-attachments/assets/d08e4911-959a-4aa8-9c21-153cc0ab7069)
