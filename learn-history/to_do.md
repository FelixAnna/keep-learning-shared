[redis 6.0](https://www.cnblogs.com/madashu/p/12832766.html)
聚集索引和非聚集索引的存储方式用什么区别（B, B+)
kafka

## 卡牌游戏 PseudoCode : https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.0&tabs=visual-studio
PokerCollection:

	kv<row, list<poker>> pokers

	bool pick(row, count) {
		if(!dic.keys.contains(row)){
			throw new Exception("not a valid row");
		}
		
		if(!dic[row].count()<count){
			throw new Exception("not a valid count");
		}
		
		pokers[row].remove(count);
		
		return true;
	}
	
	isEmpty(){
		return pokers.selectManay(x=>x.values).count == 0;
	}
	
	AddPoker(row, poker){
		
	}
	
}

Player:
	
	Name
	Status
	
	List<Command> history;
	PokerCollection collection;
	bool play(int row = 0, int count = 0){
		row = input;
		count = input;
		try {
			var result = collection.pick(row, count);
			Command.count= result;
			return true;
		}
		catch(Exception A){
			console.log(A)
		}
		
		return false;
	}
	
	SetStatus(bool win){
	}
	
	print(){
		commandHistory
	}
PokerMachine:
{
	PokerCollection collection;
	list<players> players
	
	InitialCollection(){
		PokerMachine.add(1, poker);
		PokerMachine.add(1, poker);
		PokerMachine.add(1, poker);
		
		PokerMachine.add(2, poker);
		
		players.add(XX);
	}
	
	Start(){
		do{
			foreach(var player in players){
				while(!player.play());
				
				if(collection.isEmpty){
					play.SetStatus(lose)
					break;
				}
			}
		}while(!collection.isEmpty)
	}
	
	print(){
	}
}

GameEngine:
	
	
	PokerMachine.initial();
	
	PokerMachine.Start();
	
	PokerMachine.print();


1. What is the difference between a state machine and the implementation of the state pattern?
2. think about what happened after await in C# asynchronize programming?
	
	
