# API说明

## 概念

### 游戏(Game)
一场2-10人的对战. 游戏目的为尽可能占领资源.

### 玩家(Player)
代表程序员参加游戏的代码所获得的唯一ID.

### 单元(Cell)
代表资源的最小单位, 描述一个单元的方式为X,Y坐标.

### 行(Row)
Y坐标相同的所有单元构成一行.

### 地图(Map)
一局游戏所有的单元组成一张地图.

### 基地(Base)
基地是玩家的基础领地, 所有基地被其他玩家占领, 被判为负.


## 胜利目标
尽可能多地占领单元, 占据其他玩家的领地.


## 规则
- 加入游戏, 会随机分配一个单元作为基地.
- 只能攻击自己领地相邻的单元.
- 占领不同的单元所需要的时间不同. 简单的说, 该单元被占领时间越长, 攻击它的所需时间越短.
- 所有基地被占, 判负. 同时清空所有其他被占单元.


## 测试脚本
[PostMan脚本下载](https://github.com/KevinYeti/MagCore/blob/master/script/MagCore.postman_collection.json)


## API

### 服务器BaseUrl
ht<span></span>tp://106.75.33.221:6000/

### 状态说明
[数据结构概念及状态说明](https://github.com/KevinYeti/MagCore/blob/master/api/DataMap_CN.md)

### 游戏
[创建游戏](https://github.com/KevinYeti/MagCore/blob/master/api/CreateGame_CN.md)

[获取游戏列表](https://github.com/KevinYeti/MagCore/blob/master/api/GameList_CN.md)

[加入游戏](https://github.com/KevinYeti/MagCore/blob/master/api/JoinGame_CN.md)

[开始游戏](https://github.com/KevinYeti/MagCore/blob/master/api/StartGame_CN.md)

[获取游戏详细](https://github.com/KevinYeti/MagCore/blob/master/api/GetGame_CN.md)

### 玩家
[创建新玩家](https://github.com/KevinYeti/MagCore/blob/master/api/CreatePlayer_CN.md)

[获取玩家信息](https://github.com/KevinYeti/MagCore/blob/master/api/GetPlayer_CN.md)

### 地图
[获取地图信息](https://github.com/KevinYeti/MagCore/blob/master/api/GetMap_CN.md)

[攻击单元](https://github.com/KevinYeti/MagCore/blob/master/api/Attack_CN.md)


## SDK & Demo
[C# SDK](https://github.com/KevinYeti/MagCore/tree/master/src/sdk/MagCore.Sdk)

[Demo AI](https://github.com/KevinYeti/MagCore/tree/master/src/sdk/JustRush)