# 技术问题

## 计算机是怎么做加法的？
	二进制，电路，与或非异或门等。

## 那如何用加法代替减法？
	基本数据类型大部分是有符号类型，以int为例， 32位，最高位是符号位，0代表正数，1代表负数， 0000 0000 **** 0000 表示0, 0000 **** 0001表示1， 1111 **** 1111 表示-1， 1000 0000 **** 0000 表示-128/-128*16*16/...

	正数，负数相互转换规则： 
	1. 正数 按位取反再加一就是对应的负数。比如 1： 0000 0001 按位取反得到： 1111 1110 再加一得到： 1111 1111 表示-1。
	2. 负数 按位取反再加一就是对应的正数。比如 -1： 1111 1111 按位取反得到： 0000 0000 再加一得到：0000 0001 表示+1。

## 动态规划
	k 种选择：
	自底向上从，f(1) 算起，公式：
	f(n) = max/otherOperation( f(n-1)+ f(1), f(n-2)+f(2), ... , f(n-k)+f(k))

## 常用的 Linux 命令：
	man command 命令说明书
	shutdown -h 2 两分钟后关机， shutdown -h now ， poweroff 立即关机
	shutdown -r 2 , showdown -r now, reboot ： 重启

	ls -al 查看文件列表
	ps -aux 查看进程信息
	free 查看内存使用情况
	top 查看占用资源最多的一些进程，可以按内存，CPU等排序
	
	sudo root 权限执行
	su someone 切换用户，需要someone的密码

	touch 新建文件
	mkdir 新建目录
	rm 删除
	mv 移动文件
	find 
	
	grep "xx" filename 查找xx
	grep -r -e "text" /home/ 在home 目录下查找有text 文字的文件

	sed -i 's/old/new/g' filename  替换文字
	
	vim 打开文件
	
	cat/tail/less/more 查看文件
	
	ifconfig， 查看网络情况
	
	service xx status	查看服务状态
	service --status-all
	
	netstat -an | grep 8080 查看端口占用
	
	kill -9 xx 杀进程
	
	du 相关命令查看磁盘信息，du -hl 查看磁盘剩余空间

	vim 快捷键：
	esc -> i ->: 模式切换
	dd 删除当前行
	yy 复制当前行
	p 粘贴复制的内容
	:wq, q!
	u 撤销
	. 重做
	
## http vs https
	1. https基于证书和TLS/SSL建立与客户端的安全链接，最大特点是安全性的提升，连接建立过程：
		客户端->服务端： hello
		客户端<-服务端： 你好我是服务器，这是我的CA （CA里面有公钥，证书颁发机构，颁发对象，有效期等信息）
			客户端校验CA信息，合法性，颁发机构，颁发对象，如果都通过，发送下面信息
		客户端->服务端： 向我证明你就是服务器
		客户端<-服务端： 用私钥加密发送的内容，发回给客户端
			客户端公钥解密，确定是期望的内容后，生成对称密钥和算法， 并用公钥加密
		客户端->服务器， 把生成的加密后的信息发送到服务器
		客户端<-服务器，服务器用私钥解密密文，得到对称算法和密钥， 用对称算法和密钥生成信息{ok, 我收到你的密钥了，let's go},发送给客户端
		
		客户端->服务器，用对称密钥加密请求信息，发送给服务器
		客户端<-服务器，用对称密钥解密处理请求并回复给客户端。
		。。。。
	2. 安全提升
		发送数据之前，添加随机串， 然后把请求信息+随机串 hash值也放到请求中，并一起加密；
		另外一端（服务器）：解密请求信息，判断随机串用没有出现过， 出现过说明请求可能是被重发的（中间人捣乱），可以停止请求，拒绝服务。否则继续计算hash 值，如果不一致，说明被恶意篡改，也可以拒绝服务。
		
参考资料： 【[CSDN](https://blog.csdn.net/xiaopang_yan/article/details/78709574)】 【[知乎](https://zhuanlan.zhihu.com/p/27395037)】
	
## CAP 理论：
	C: Consistency, A: Availability, P: Partition Tolerance
	C: 数据一致性， 数据在多个分区上存储的副本完全一致；
	A: 任何时候访问数据都可以得到明确的响应，存在就返回数据；
	P: 数据跨多个分区节点存储，一个分区故障，数据仍然能被从另外分区访问到。
		意味着要写多个分区， 如果同步写，必然有一段时间，数据是不可用的。如果异步写，必然有一段时间，数据是不一致的。
	
	BASE：基本可用（Basically Available）， 软状态（Soft State），最终一致性（Eventual Consistency）。他是CAP理论的延申.
	基本可用： 当系统遇到局部故障时，系统的请求响应时间会延长，但不会不可用，系统非核心服务可能会被降级（如双十一，评论页面可能会被引导到降级页面）。
	
	软状态：系统允许出现中间状态，而中间状态不会影响系统整体的可用性，比如允许多个副本之前数据同步的延时，数据库异步的读写分离等。
	
	最终一致性：系统中的数据的所有副本，经过一定时间后能达到最终一致的状态，是弱一致性的表现。
	
## 最近看了什么书？
	Java 8 编程参考官方教程: java 8 基础知识，类库，语法，GUI编程（applet, Swing, JavaFX）;
	C# via CLR ： C# 基础 加 部分底层实现，代码优化技巧 ;
	
	Spring in Action 4 & 5 : Spring Initializer, Basic Configuration , 服务通信（Feign, RestTemplate, WebClient）, API, WebFlux, Test (Mockito, MockMVC, WebTestClient, RestTemplate) , JPA, Spring Clould Config, Eureka, Spring Cloud Gateway, Spring Boot Admin
	大型网站技术架构: 分层，业务拆分，分布式，集群，缓存，CDN，异步, 冗余, 自动化，安全（XSS, CSRF， 注入，CORS，sonar代码扫描, penetration test 渗透测试），监控（日志监控，cpu内存等），报警（Devops， developer），CAP, 备份， 分库，分表，分页，风控（基于规则和统计）
	
	架构师的修炼技术技能 + 软技能 ： 个人目标与团队目标一致， 建立信任关系，放权并成就他人， 保持透明，保持正直，不公开批评他人（私下沟通）， 维护不在场人的利益，决策记录，边界引入创新，关键决断先单独约见利益相关方，开放胸襟，诚实对人，互助和分享。不做过多假设。了解业务（逻辑和怎么给公司盈利），光明正大地竞争，核心利益不妥协。
	
	****算法导论： 插入，归并（分治法），快排及随机化, 桶排， 堆排序； 散列算法；平衡二叉树；动态规划；最长公共子序列；贪心算法；图和它的最短路径算法；
	
	***Headfirst 设计模式： 策略， 单例，工厂，抽象工厂， 适配器，外观， 模板， 迭代器， 组合， 状态， 命令， 观察者，代理，建造者，
	
	高效能人士的七个习惯 ：积极主动 （Be Proactive），以终为始 （Begin with the end in mind），要事第一 (Put first Things first)，双赢思维（Think Win-Win） ,知彼解己（Seek first try to understand, then to be understood）, 统合综效 (Synergize-协同合作)， 不断学习(Sharpen the saw).
	
	自己写框架的书（名字忘了，类似spring框架，通过反射，注解，生成动态代理等方式实现简单框架）
	历史，科学 （明朝那些事，上下五千年，科学有故事）
	哲学（阳明学: 心即理，性情皆为人的本性，不可能去掉情，要把情控制在合理范围内；事上磨， 主张出世而不是避世，练就心性；知行合一，行动要符合良知，良知告诉我该做的就做，不该做的就不做。）
	
	看了对自己影响和提升不大的书（翻译官方文档或内容质量不高等）

## 值传递和引用传递的区别
	我们可以理解为值传递和引用传递，都是把变量进行copy 后传递，值传递不会改变原来变量的值，因为值类型是不可变的，引用传递会改变原对象的值，因为copy的引用还是指向同一个对象。
	
## HashMap, HashTable, CurrentHashMap, Collections.sychronizedMap(HashMap) 区别：
	HashMap 不是线程安全的，单线程情形下性能更高，继承AbsractMap；
	HashTable 是java 遗留类，线程安全，但是实现线程安全的方式是所有读写都用sychronized 代码块锁住整个HashTable，所以性能较低，不推荐用；
	Collections.sychronizedMap(HashMap) 是线程安全的，实现类似HashTable， 但是因为属于集合类，所以可以用来替代HashTable 使用；
	ConCurrentHashMap 是线程安全的， 但是它把整个map 分成多个片段，操作哪段锁哪段，所以读写更高效。	
	
## SpringBoot 和 SpringMVC 的区别
	Spring Boot旨在简化spring开发，spring boot 有众多启动（starter)项目，这些项目有3个特点，自动引入相关依赖（根据依赖传递性规律），确保依赖中不同的组件相互兼容，@SpringBootApplication 注解可以激活自动扫描，自动配置（如果引入了starter 依赖，但是有没有定义部分通常需要的Bean的话，它会推断并自动配置相关组件），我们只需要配置少量不方便推断出来的Bean。
	
	Spring MVC 是MVC设计模式在Spring框架上的具体实现，它享有Spring 的所有优点（IOC,DI, 事务切面，AOP等），它利用MVC的理念，把视图层，控制器，数据层分开， 视图层可以适配各种前端框架和设备，具体以来前端的实现和视图层解析器的配置等， 数据层一般又可以分为模型和服务层，服务层可以使用注解式事务，或者自定义AOP切面，来实现关注点和业务的分离。

## Spring Java Bean 的加载过程

	Spring 使用容器来管理Bean， 所以首先我们会初始化容器， 和扫描bean 的配置。 然后我们会根据bean 的配置和scope 初始化bean 并放到容器来以便使用。默认情况下bean 都是单例，我们会在容器初始化后立即初始化和装载所有bean。如果某些bean的生命周期配置的不是单例，可以是Prototype，Request，Session等，Prototype 的bean， 每次注入都是一个全新的bean，如果是Request， 则每个请求里第一次用到会创建这个Bean， 后面即便再注入，也是同一个bean， 直到请求结束，这个bean 被destory。Session级别的Bean通常是保存登录信息。
	
## Java == 和 equals

	==， 用于值类型比较，比较值是否相同； 用于引用类型比较，比较引用地址是否相同；
	equals： 用于引用类型比较，如果两边是同种包装类型，则比较对应值类型，否则返回false。

	集合类比较相等(distinct)： 重写equals，如果是hashtable/hashMap/hashset/等带hash 的集合类还要重写hashCode， 比较的时候会先比较hashCode，再比较equals
	集合类排序(sort)： 可以用方法引用排序 sort(X::getId) ， 也可以自定义实现Comparable 接口的 compareTo 方法，返回基本类型。
	
## JVM 垃圾回收机制
	JVM 垃圾回收算法根据不同JVM厂商可能会有所不同，有标记清除算法，标记整理/压缩算法，复制算法，引用计算器算法（废弃）等多种。
	标记清除算法(Mark-Sweep)：从根节点找出所有可达的对象，剩下的就是可回收对象，然后清除这些可回收对象的空间。 缺点：全部对象扫描，性能慢；空间碎片化；大对象可能没有连续的足够空间。
	
	标记整理算法(Mark-Compact): 从根节点开始找出所有可达对象，剩下的就是可回收对象，然后将所有活动的对象压缩到内存块中的一端，剩下的空间全部清理。它适用于对象存活率较高的场景，一般用做老年代的回收算法。
	
	复制算法：复制算法把内存分为2个块（eden+from , to）, 它会把存活的对象从一个块中（eden+from）复制到另一个块中（to）, 然后清除原来的块（eden + from）, 最后交换两块的职责（to 和 from 交换: new from = to , new to = from），下次回收时再次执行相同的过程（eden+new from， new to），以此类推。 标记整理算法主要用于JVM新生代垃圾回收，对于对象存活率一般较低的新生代，效率是上述几种算法中最高的。
	
	JVM 的堆一般分为三代，新生代(eden + Survivor0 + Survivor1), 老年代（Old 或 Tenured), 永久代（perm）(java8 开始叫元空间：metaSpace，职责基本相同但不再是堆的一部分)
	
	新生代： 新生代主要分为eden, s0, s1, 空间比例8：1：1，s0 和 s1 交替存储活动根；如果GC被触发，则会用复制算法回收eden+from区到to 区； 如果to区满了，则会把所有To区活动对象复制到老年代。如果新生代对象年龄达到一定值（默认15），该对象直接被移动到老年代。每移动一次，对象年龄加一。
	
	老年代： 用来存储从新生代复制过来的对象，或者触发对象大小上限，直接存储再老年代的对象。如果老年代满了或者被触发GC老年代回收，则会用标记整理算法回收老年代。如果回收后仍然不足，则会报OutOfMemory 异常。
	
	永久代（perm）或者 元空间（MetaSpace)：永久代从JDK8 开始已经被MetaSpace 替换，它已经不属于JVM堆的一部分，不在JVM中，而在本地内存中(所以大小不在受JVM限制，理论上最大可以是可用内存大小行行x64 位系统4GB)。但是它仍然主要是存储类的信息，常量池，方法数据，方法代码等，它主要解决的是由于永久代（以前JVM方法区）内存不够用导致OutOfMemoryError的问题。
	
	这些代（+MetaSpace 大小等都是可以通过命令调节的）。

## Sleep ， Wait:
	Sleep 不会放弃CPU，wait 会让当前线程放弃CPU时间，进入线程池中等待，并释放系统资源。
	
## 乐观锁，悲观锁
	乐观锁假设大部分的操作都是读取，很少是写入，所以他在修改对象时，先完成修改，在复制到原对象时比较当前对象和预期对象的旧值，一致的话才发布对象新值，否则放弃操作或者做自旋（spinning）。
	悲观锁会先锁住对象，再更新对象，获取锁得过程性能比乐观锁差很多，而且锁住了数据，导致数据行（或表）可用性变差，其他线程暂时访问不了被锁住的数据，只能等待，导致性能变差。 容易产生死锁；
	
	MYSql 更新如果使用索引，是行级的锁，否则是表级的锁。
	
## Volatile， AtomicInt (AtomicXX), CAS
	volatile: 此关键字用来保证内存可见性（每次读取前必须从主内存刷新最新值，每次写入后立即同步到主内存中）和防止指令重排，但不保证原子性；
	AtomicXXX: 既能保证内存可见性，防止指令重排，又能保证原子性；
	CAS: Compare And Set, 是非阻塞的，轻量级的乐观锁，CAS 有三个数据，内存位置的原始值，预期原值，新值， 在把新值发布到内存位置之前，会比较内存位置的原始值和新值是否一致，一致再发布。 如果不一致，一般会sleep 一小会再重新执行一定次数的CAS操作,这个过程也叫自旋。它没有用到锁也能实现同步，但是确定是他会在这个过程中持续占用CPU。
## 内存可见性
	使用 volatile 修饰共享变量后，每个线程要操作变量时会从主内存中将变量拷贝到本地内存作为副本，当线程操作变量副本并写回主内存后，会通过 CPU 总线嗅探机制告知其他线程该变量副本已经失效，需要重新从主内存中读取。Java 中的各种锁也能保证内存可见性（synchronized) [参考](https://zhuanlan.zhihu.com/p/138819184)

volatile 保证了不同线程对共享变量操作的可见性，也就是说一个线程修改了 volatile 修饰的变量，当修改后的变量写回主内存时，其他线程能立即看到最新值。
## 偏向锁（无竞争），轻量级锁（交替执行），重量级锁（有竞争，且自旋获取也失败才升级），
	Synchronized　在JDK８＋中默认使用偏向锁，锁信息是放在对象头中的，初始化时是无锁状态，当线程执行同步代码块（方法）时，会把对象头中的锁状态改为偏向锁，线程ID改为当前线程。
	当当前线程执行完，以后再进入到同步块时，会检查对象头锁信息，发现是同步锁，并且是当前线程ID，则说明当前线程重入了同步块，直接执行。
	当另外一个线程需要执行同步代码块时，如果发现对象头是偏向锁而且指向另外一个线程ID，说明出现了竞争，他会尝试用CAS机制获取锁，如果成功，则执行并把对象头线程ID改成自己的。如果失败，则进入等待，把当前线程ID放到等待列表中，并把当前锁升级为轻量级锁。待下次线程暂停（到达safepoint，全局安全点）后，切换执行当前线程。
	**TODO: 轻量级 和重量级锁明确**
	
## 适应性自旋（Adaptive Spinning），锁粗化（Lock Coarsening），锁消除(Lock Elimination)，
	轻量级锁获取过程中，如果第一次获取不到，会通过自旋来重试一定次数，JDK采用了更聪明的机制，简单来说，如果获取成功，下一次会自旋更多次,反之如果获取失败了，下次spin次数更少。
	
	锁粗化，如果几个连接在一起的锁合并成一个锁（加锁和解锁的过程合并成一次），例如连续的StringBuffer append 操作；
	
	锁消除，系统会智能的删除不必要的加锁操作，利用代码逃逸技术，判断堆上的数据不会逃逸出当前线程，就会取消加锁解锁操作。
	
## 自增主键， UUID(GUID), 有序UUID
	自增主键： 在数据库中可开启，能保证自增列的原子性，不会重复，占用空间小（一般用Long），主键有序递增，索引查询快。缺点是如果需要数据同步，数据合并会导致主键冲突。还有是依赖数据库生成主键，
	GUID: 可以保证全局唯一，即便是数据合并（新老库）的情况下。但是guid本身不能保证顺序，导致插入数据时，会导致索引和表数据的重排（主键一般使用聚集索引，索引顺序和表顺序一致）。
	有序GUID: 通过在GUID 头部（适合MySQL） 或者尾部（SQL Server）添加自增数字的方式来达到既保证全局唯一性，又保证有序自增, 防止大量的索引重排和表数据移动问题。
	
## B+ 树
	B+ 和 B 树一般是关系型数据库存储的结构，他们都是平衡多叉树，B树的根节点，中间节点和叶子节点都保存的有数据，查询时从根节点开始遍历，直到查找到了指定数据或者遍历结束为止。
	B+ 树相对于B树的改变主要有，它不再把数据（记录的指针）放在非页子节点，非页子节点只放索引，数据记录指针只放在页子节点中，而且页子节点之间也有指针相连（即便是不同的父节点），这样有利于范围查找和数据库用索引做全表扫描（直接遍历所有页子节点）。
	
	B*树是B+树的改进，主要改进是非页子节点直接也加入了指针（不同父节点），以至于在非页子节点需要拆分时，可以和相邻节点协调： 如果相邻节点也满了，就各拿出1/3建立新节点，以减少对更多节点做修改的可能性。
	
	参考： https://zhuanlan.zhihu.com/p/27700617
	
## 主键索引，唯一索引，复合索引, 普通索引，全文索引
	主键索引是特殊的唯一索引，索引值必须非空， 他是聚集（clustered）索引（索引数据的顺序和物理行一致，这也是一个表为什么只能有一个聚集索引）。
	(聚集索引是一种索引，该索引中键值的逻辑顺序决定了表中相应行的物理顺序。)
	唯一索引，要求列唯一，可以有唯一的NULL
	组合（复合）索引，采用多个列组合建立的索引，可以减少二次查询，查询时要注意使用左侧的一到多列，索引才会被使用，没有最左侧的列索引就不会使用。
	
	复合索引 和 唯一索引 都是非聚集索引（如果不是主键索引的话），他们的索引页子节点指向的是数据块，如果查询的列被索引列覆盖（可以有非聚集索引的index列），则会进行二次查询，扫描索引指向的行，获得未被索引覆盖的列信息。
	
## 行锁，表锁，排他锁，共享锁 （for InnoDB)
	mysql 事务要关闭autocommit （默认自动提交），set autocommit=0;
		begin; 事务逻辑; commit;
	如果查询（或更新的时候）命中了聚集索引，mysql 默认锁行， 否则会锁表。
	如果是更新操作或者selelct 用了 for update, 会使用排他锁
	***select 通过指定 select xxxx lock in share mode 使用共享锁

	参考： https://www.solves.com.cn/it/sjk/MYSQL/2019-08-29/4050.html
	
## Http/ TCP / IP, HTTP（实际是TCP）慢启动，HTTP2
	客户端发送请求到服务端之前，会先通过DNS解析（缓存DNS，本地DNS，远程DNS）得到服务器IP 地址；http 用这个IP地址生成到服务器的请求； 请求报文被TCP 分割成多个报文段并发送并获取发送结果ACK；IP协议复制具体发送（发送->中转*n->目标）报文。服务器端TCP协议会把接收到的报文重新组合，服务器端HTTP根据请求路径和报文做出响应；响应TCP拆分为多个报文，多个报文被用IP协议发送给客户端，客户端TCP接收到报文后组合报文，获得请求响应信息。
	
	HTTP慢启动(拥塞控制)：
	初始建立连接的过程中，HTTP 请求被TCP分成多个报文段后，TCP不会一次性把这些报文段都发过去，而是先发一个，如果得到ACK，再发两个，如果得到ACK再发四个。。。直到达到限值或者出现发送失败，丢包情况，说明达到了阈值，才不再以指数式增加。这一过程叫做HTTP慢启动。
	
	HTTP2： 相对于HTTP1.X 的区别主要有，多路复用支持单个连接（同域名下所有请求只有单个连接）同时发送多个请求信息（不用等到请求响应再发另外一个请求），二进制分帧， 请求和响应采用二进制格式发送（不是1.X纯文本格式）, 二进制帧解析和压缩都更高效。头部压缩，HTTP2 堆头部采用专用算法HPACK压缩，减少传输流量；服务器推送, HTTP2 在客服端和服务器端建立连接通道之后，服务端根据请求信息（如index.html),可以推送关联信息给客户端，减少客户端请求次数，而且推送的内容会被缓存在客户端，客户端后面可以直接使用。

	QUIC/HTTP3: QUIC provides native multiplexing 

## 给一个方法加超时：

	FutureTask 包装需要设置超时的方法，ExecutionService.execute(futureTask), 然后futureTask.get(timeout, TimeUnit.MILLIONSECONDS);
	(Task in .net can do the same thing)

## Future, FutureTask, CompletableFuture,;
	接口Future<T> (Callable<T>), 结合Exectores 使用，能拿到返回结果， 而且还可以控制执行过程（cancel， isCancelled, isDone, get(),get(timeout);
	FutureTask<T> 实现了Future<T> 和 继承了Runnable， 可以结合Exectores 或者Runnable 使用，能拿到返回结果和控制执行过程。他是Future<T>的具体实现。
	CompletableFuture 也是Future<T> 的实现，但是它还实现了CompletionStage， 可以流式的执行多个同步或者异步代码块或方法。它默认使用ForkJoinPool.commonPool 来执行并行任务。对标.net 的Task 类， 可以 supply/apply/run (async) (ContinueWith), 也可以用allof 确保所有完成，或者anyof只要一个完成就继续，最后调用whenComplete/whenException出来结果或异常。
	但是他的cancel 因为不保证在独立线程上执行，所以是cancel exceptionly，可能不能完全cancel （Future 的总是再独立线程执行，所以可以cancel 线程），

## 多线程：
	Thread / Runnable: 继承Thread（或者实现Runnable），启用多线程， 缺点是不能拿到返回值，不使用线程池；
	Future<T>, Callable<T>(or Runnable）或者FutureTask<T>, 可以更多的控制线程（cancel， get， get（timeout), isDone() etc.)
	Executors.newCachedThreadPool or Executors.newFixedThreadPool or Executors.newScheduledThreadPool: 返回ExecutorService 接口，提供Future<T> submit(Callable<T>) 或者 execute(Runnable) 两种方式开启线程。
	CompletableFuture<T>, 更方便的启动多线程，还可以流式（或者说链式）操作（supplyAsync/applyAsync/runAsync + thenXX /thenXXAsync), Async means 默认交给ForkJoinPool 中的线程执行， then 不带Async交给当前线程继续执行。我们有一系列的操作，有些需要顺序执行，有些需要多个子过程全部并行执行完再继续，有些需要返回值，有些需要使用前一步的返回值，有些不需要使用前一步的返回值也不返回任何结果，有些需要把两个CompletableFuture 的两个结果聚合（thenCompose),这些CompletableFuture 都可以很好的支持。

## 线程池：
	降低频繁创建线程的开销，有默认最小线程数(corePoolSize)：维护最小线程数量， 最大线程数（maximumPoolSize）：最大可以并行执行的线程数, 空闲时间（keepAliveTime)：大于最小线程数的线程空闲超时释放时间, 等待队列（BlockingQueue<Runnable>)：等待执行的任务列表 组成。
	任务到达线程池时：
	a. 池里如果有空闲线程的，会立即用空闲线程执行任务。
	b. 池里线程都繁忙，会把线程放到等待队列中；
	c. 等待队列如果繁忙，池里线程数小于最大线程数，则会创建新线程执行任务；
	d. 等待队列如果满了，池里线程数等于最大线程数，则会抛出异常；
	
	Executors.newCachedThreadPool: 最小线程数0，最大线程数int.MAX_VALUE (2^31 - 1), 超时时间60s， 队列是一个没有容量的BlockingQueue （插入一个线程任务之前会等待另一个线程被从队列移除），所以意味着他会不断地创建线程，如果提交线程任务的速度高于线程处理的速度，会导致创建过多线程而耗尽CPU，内存资源。
	
	Executors.newSingleThreadExecutor: 确保或者尽量（如果线程挂了，会新开一个）使用一个线程顺序处理所有任务，确保唯一性（Executors.newFixedThreadPool(1)也是类似，但是它可以被重新配置使用更多线程，newSingleThreadExecutor 返回的类型确保不会被重新配置）。
	
	Executors.newFixedThreadPool(size), 指定最小线程数和最大线程数都是size， 永不超时，队列大小是int.MAX_VALUE.
	
	Executors.newScheduledThreadPool(size), 最小线程数size，最大int.MAX_VALUE, 永不超时，队列是一个DelayedWorkQueue； 它可以指定一段时间后或者一定间隔重复执行任务。
	
## ClassLoader:
	应用程序默认的类加载器是Application ClassLoader， 它的父加载器是Extentision ClassLoader (加载$Java_HOME%/lib/ext下面的库），它的父加载器是Bootstrap ClassLoader (C++实现）， 加载$Java_Home%/lib 下面的类库，Application ClassLoader 加载时，会委托给父类加载器加载，父类委托给根加载器，只有当他们加载不到时才会由子类加载器加载，这就叫类加载的双亲委派，他确保相同的类都由同一个类加载器加载（如果是不同的类加载器加载会导致jvm认为他们不是相同的类）。
	
## 双重检查锁
	
``` Volatile 确保指令的执行顺序 和 对象的内存可见性（读取：立即从内存读取，修改：立即发布到内存）
volatile Instance instance;

getInstance(){
	if( instance is null)
		lock(Instance.class){
			if(instance is null){
				instance=new Instance();
			} else {
				return instance;
			}
		}
	else{
		return instance;
	}
}
```
	
## Redis 数据类型：
	String：类似于Memcache的Key(Value)存储，一个String Key 对应一个Value。
	Hash： 存储键值对集合，指定数据集名 和 key (value),存取对象。
	List： 保持元素的插入顺序， 指定数据集名，顺序，range 访问。
	Set： 去重无序存储数据集
	ZSet: 去重有序存储数据集（需要给定score）
	
	特性： 高性能（读写都挺快），数据会持久化存储，丰富的数据类型，支持pub/sub，过期等操作。
	支持主从模式，3.0以上也支持集群模式（内部主从模式），集群模式的Redis 内部节点是互联的，集群内部如果检测到某个节点半数以上的连接都失败了，就会把这个节点标记为fail。如果master 失效了，会把对应的slave 升级为master。 如果都失效了，集群就不能再提供服务了。
	
	
## S.O.L.I.D Principles

	Single Responsibility Principle, 单一职责原则， 改变类的的原因应该只有一个，修改或者添加与当前职责有关的相关功能（不是说只有一个方法）。类不应该有多个维度（相对）的相关职责，否则会导致修改一个维度的相关职责可能影响另一个维度完全不相干职责的正常工作，也可能导致另一个维度依赖模块的被动更新。而且类的职责太多，会导致可维护性也变差。
	
	
	Open / Close Principle, 开闭原则，
	Software entities（class, component, functions) should be open for extension, but close to  modification, 表面上看它是建议我们用继承来取代修改原有类，以提供原有方法的不同实现，或者添加新方法实现， 但是更好的方法是通过多态化来为相同接口提供不同实现来修改原有的方法（或者实现新接口以添加新方法），高层模块只需要以来接口，注入新实现类就可以实现需求。
	不过如果更看重代码重用，也可以用继承 或 组合的方式来避免违反开闭原则。
	
	Liskov Substitution Principle，里氏替换原则，
	程序中任何父类（接口），出现的地方，都可以被他的所有子类替换，而且不会破坏程序运行。也就是要求，parent and all children 有相兼容的方法签名和行为，尤其不允许parent 有实现一个方法，但是子类继承了他，去throw not implement exception. 如果出现此类问题，就违法了Liskov Substitution Principle。表明parent 的职责需要细化或者parent/child 职责设计不合理。
	
	Interface Segregation Principle, 接口隔离原则，
	Child 不应该依赖它不需要的接口，如果出现了相关问题，表明我们的接口需要拆分细化， 不需要一个万能的大接口，二是需要很多职责单一的小接口。
	
	Dependency Inversion Principle, 依赖倒置原则，
	高层模块（high level modules)不应该直接依赖于低层模块， 他们都应该依赖于抽象：高层模块实现相关抽象，低层模块也实现对应抽象， 高层模块的实现依赖低层模块的抽象。这样有利于降低模块之间的耦合。

## Cache Strategy
	ref: https://bluzelle.com/blog/things-you-should-know-about-database-caching 
	
#### Cache aside
	1. application service query data from cache service, if have data then return;
	2. application service then query data from DB;
	3. application service then write data to cache service, so it can be hit next time;
	4. application service return data.
	
#### Read Through ()
	1. application service read data from cache service, if have data then return;
	2. if dont have data, cache service will load data from db internal;
	3. cache service update cache;
	4. cache service return data to application service;

#### Write Through
	1. Service Write data to cache;
	2. Cache Service then write data to DB;

####  Write Back
	like write through, but not write to db immediately, flush to database every x minutes/seconds;

#### Write Around
	1. directly write to db
	
	usually work with cache aside / read through policy.

## 设计模式

#### 策略模式（Strategy Pattern）

某个类需要依赖一组算法，而且需要在运行时能够动态的替换算法的实现时，使用策略模式可以通过定义一组算法，并让使用这些算法的类依赖这些算法的共同接口对象（调用者也可以实现算法接口），同时提供动态替换算法接口的方法，来达到把这个变化的部分（算法）封装起来，使用者只依赖算法的抽象而不依赖任何实现的目的。符合Open-Close原则，通过组合而不是继承来封装变化和降低耦合。

```
	Interface IStrategy{
		void doSomething();
	};
	
	Class AStrategy implement IStrategy{
		public void doSomething(){
		}
	};
	
	Class BStrategy implement IStrategy{
		public void doSomething(){
		}
	};
	
	Interface Context{
		void doSomeMore();
	}
	
	Class AContext { 
		IStrategy strategy; 
		
		//动态替换能力
		public IStrategy getStrategy(){
			return strategy;
		}； 
		public void setStrategy(value){
			strategy = strategy;
		}; 
		
		public void doSomeMore(){
			//do more or nothing
			...
			
			strategy.doSomething();
		}
	}
```
	
#### 装饰器模式（Decorator Pattern）

装饰器模式可以在不修改原接口和类的情况下，动态的修改原接口的实现，或者添加新的方法。装饰器接口（或者抽象类）扩展原接口，装饰器类实现装饰器接口，并提供原接口变量装作为实例变量（或者通过构造方法传入），装饰器实现原接口方法时，可以在调用被装饰者对象前后做额外处理，也可以提供新的方法。

```
	Interface Target{
		void doSomething();
	}
	
	class ATarget implement Target{
		void doSomething(){}
	}
	
	Interface Decorator extends Target{
		void doMore();
	}
	
	class ADecorator implement Decorator{
		Target target;
		public ADecorator(Target target){this.target=target;}
		
		void doSomething(){
			//do more or nothing
			...
			
			target.doSomething();
		}
		
		void doMore(){
			//do more
			...
		}
	}
	
	Target target = new ATarget();
	Decorator deco = new ADecorator(target);
	
	deco.doSomething();
	deco.doMore();
```

#### 适配器模式(Adapter Pattern)

提供一个适配器类，把一个接口转换为客户希望用的另一种的接口。通过适配器，可以使原本不兼容的接口可以一起工作。

```
	Interface Square{
		void doSomething()；
	}
	
	class BlueSquare implement square{
		void doSomething(){}
	}
	
	Interface Cubic{
		void doSomethingElse()；
	}
	
	class SquareAdapter implement Cubic{
		Square square;
		public SquareAdapter(Square square){this.square = square;}
		
		public void doSomethingElse(){
			square.doSomething();
		}
	}
	Square square =new BlueSquare();
	Cubic blueSquareFakeCubic = new SquareAdapter(square);
	
	blueSquareFakeCubic.doSomethingElse();
```

#### 外观模式（Facade Pattern）

隐藏复杂的子系统接口，提供一个简单易用的接口供使用者调用。

```
	Interface One{
		void doSomething();
	}

	Interface Two{
		void doSomethingElse();
	}
	...

	Interface Facade{
		void doEveryThing();
	}

	class AllFacade implement Facade{
		One one;
		Two two;
		...
		
		public AllFacade(One one, Two two){this.one=one, this.two=two;}
		void doEveryThing(){
			one.doSomething();
			two.doSomethingElse();
			...
		}
	}
```

#### 观察者模式(Observer Pattern)

主题（subject）在有更新时会动态的通知此主题所有的订阅者，也就是主题维护了一个抽象订阅者列表，订阅者依赖抽象主题，一旦主题更新，会通过订阅者列表立即通知所有订阅者，数据可以在通知时传递或者订阅者使用主题对象自己拉去。

```
	Interface Subject{
		void onChange();
		
		void subscribe(Listener listener)；
		void cancelSubscribe(Listener listener)；
	}

	Interface Listener(){
		void doSomethingElse();
	}

	class ASubject(){
		List<Listener> listeners;
		
		// private event EventHandler<TArgs> XXHandle;  //in C# we have event + delegate (EventHandler<T>) which helps implement this
		
		public ASubject(){listeners =new AarrayList<>();}
		
		void subscribe(Listener listener){
			listeners.add(listener);
		}
		void cancelSubscribe(Listener listener){
			listeners.remove(listener);
		}
		
		void onChange(){
			//do something
			...
			
			notify();
		}
		
		void notify(){
			listeners.forEach(x->x.doSomethingElse());
			// var handers = XXHandle; handlers(xxx); //for C#
		}
	}

	class AListener(){
		Subject subject;
		public AListener(Subject subject){
			this.subject = subject;
			this.subject.subscribe(this);
		}
		
		void doSomethingElse(){
			//do sonething
		}
	}

	Subject subject=new ASubject();
	Listener listener =new AListener(subject);
	subject.onChange();
```

#### 单例模式 （SingleTon Pattern）

确保对象只有一个实例，并提供一个全局访问点。

```
public class SingleTon{
	private volatile SingleTon singleTon;
	
	SingleTon getInstance(){
		if (singleTon == null){
			synchronized (SingleTon.class){
				if( singleTon == null){
					singleTon = new SingleTon();
				}
			}
		}
		
		return singleTon;
	}
}
```
	
#### 命令模式 （Command Pattern）

将请求封装成命令，解耦请求发起者和请求调用者，可以支持execute和 undo，同时可以在程序中传输，保存或者回复。线程池队列就是命令模式的一个实例。除此之外，某些异步系统也有命令模式的影子，比如需要日志来记录执行过程，以便万一系统处理失败或者宕机可以恢复。

```
Interface Command{
	void execute();
	void undo();
}

class ACommand implement Command{
	Exchange target;
	
	public ACommand(Exchange target){
		this.target=target;
	}
	
	public void execute(){
		target.buy();
	}
	
	public void undo(){
		target.sell();
	}	
}

class BCommand implement Command{
	Index target;
	public BCommand(Index target){
		this.target=target;
	}
	
	public void execute(){
		target.buy();
	}
	
	public void undo(){
		target.sell();
	}	
}

List<Command> commands = new ArrayList<>();
commands.add(new ACommand(new AExchange()));
commands.add(new BCommand(new AIndex()));
commands.forEach(x->x.execute());

```

#### 工厂模式（Factory Pattern）

工厂模式把产品的实例化过程交给工厂的实现类，调用者不用关心产品实例化的细节。工厂方法之用于创建一种产品（同一接口），抽象工厂一般用来创建一组产品（每个产品实现不同的接口）。

```
//工厂
Interface Product{}

class AProduct implement Product{}

Interface Factory{
	Product getProduct();
}

class AFactory implement Factory{
	public Product getProduct(){
		return new AProduct();
	}
}

//抽象工厂
Interface ProductA{}
Interface ProductB{}

class OneProductA implement ProductA{}
class OneProductB implement ProductB{}

Interface Factory{
	ProductA getProductA();
	ProductB getProductB();
}

class AFactory implement Factory{
	public ProductA getProductA(){
		return new AProductA();
	}
	
	public ProductB getProductB(){
		return new OneProductB();
	}
}
```

#### 模板方法 （Template Pattern）

模板方法提供一个方法框架，框架中的部分实现交个子类实现（允许子类决定方法实现的部分细节）。

```
abstract class Template{
	public void method(object o){
		//doSomething
		...
		
		if (compareTo(o)>0){
			//...
		}
	}
	
	public abstract int compareTo(object o);
}

class OneTemplate extends Template{
	public int compareTo(object o){
		return o!=null 1: 0;
	}
}
```

#### 迭代器模式（Iterator Pattern）

提供一种统一的方法，以便可以顺序的访问集合中的元素，而不用关心集合的具体实现（主要有hasNext(), next(),remove() 3个方法），java/.net 中已经有了迭代器接口，集合类已经实现了迭代器接口。也可以自己实现。

```
Interface Iterator{
	bool hasNext();
	Object next();
}

class Someclass(){
	String[] values;	
	
	Iterator getIterator(){
		return new SomeclassIterator(this);
	}
}

class SomeclassIterator implement Iterator{
	Someclass clazz;
	int position =0
	
	public SomeclassIterator(Someclass clazz){this.clazz = clazz;}
	
	bool hasNext(){
		if(position<clazz.getValues().length){
			return true;
		}
		
		return false;
	}
	
	Object next(){
		if(position<clazz.getValues().length){
			clazz.getValues()[position];
			position++;
		}
		
		return null;
	}
}
```

#### 组合模式 （Composite Pattern）

程序中的多个对象或者或者集合之间有树状层级关系，我们希望有个一统一的方式处理对象（不管是页子节点还是集合），就可以使用组合模式让他们实现统一的接口（违反接口隔离，单一职责，里氏替换原则）。实用场景包括组件的层级关系，我们通过调用父组件可以递归的调用子组件渲染，更新等。

public interface INode {
	void Render();
}

public class LeafANode implement INode {
	public void Render(){}
}

public class LeafBNode implement INode {
	public void Render(){}
}

public class IBranch extends INode {
	List<INode> children;

	void Add(INode node) {
		children.add(node);
	};
	void Remove(){
		children.remove(node);
	};

	void Render(){
		children.foreach(x=>x.render());
	}
}



#### 代理模式 （Proxy Pattern）

通过包装并提供对代理对象的访问，而且可以动态的把职责加到代理对象的执行前后。

#### Proxy vs Decorator
They almost have the same syntactical implementation (can add / remove logic before or after a function), 
but decorator focus on add functionality for the fuction.
while the proxy is focus on control access to object/fucntion (security/logging/transaction/performance).
proxy partten often only allow access to the proxy class (restrict to the original one)

#### 责任链模式（Chain of Responsibility Pattern - CoR）
Pass a request to a chain of potential receivers until one of them handles it.
```
public interface Handler
{
	Handler setNext(Handler h);
	void handle(request);
}

public abstract class BaseHanlder implement Handler{
	protected Handler next;
	public Handler setNext(Handler h)
	{
		next = h;
	}
	void handle(request);
	
}

public sealed class WeatherHanlder implement BaseHanlder{
	public Handler setNext(Handler h)
	{
		base.setNext(h);
	}
	
	handle(request){
		//do something
		....
		
		if(next != null)
			next.handle();
	}
}

//define handlers
var handle =new WeatherHanlder();
handle.setNext(colorHandle).setNext(tempHandle);

//process request somewhere
handle(request);
```

## 建造者模式 (Builder)
create an object step by step, or many optional paramters in the construct

public class Car{
	string id
	string name
	string weight
}

public class CarBuilder{
	private Car car;

	public CarBuilder(){
		car = new Car();
	}

	public CarBuilder id(string id){
		car.setId(id);
		return this;
	}

	public Car Buid(){
		return car;
	}

}

var car=new CarBuilder().id("a").name("name").Buid();

## 桥接模式（Bridge）

## 原型模式 （Prototype）
Clone object (include private) to a new object

interface ICloneable{
	object Clone();
}

public class Component implement ICloneable{
	string id,
	string name,

	public Component(string id, string name){
		this.id=id;
		this.name=name;
	}

	@override
	public object Clone(){
		return new Component(id, name)
	}
} 

public class SubComponent extends Component{
	int age;
	public SubComponent(Component component, int age){
		super(component.id, component.name);
		this.age=age;
	}

	@override
	public object Clone(){
		return new SubComponent(this, age)
	}
} 

## 分布式事务

#### XA

两阶段提交协议，事务协调器（TM）调度各个资源管理器（RM），准备执行事务，所有RM 执行Prepare过程，TM检查所有RM Prepare 是否全部ok， 全部ok的话在通知各个RM提交事务，否则通知各个RM全部rollback。

XA需要数据库层级的支持（MYSQL， Oracle已经支持），代码侵入少，但是会同时锁住所有资源。

#### TCC

类似于XA两阶段提交协议，但是需要每个RM自己实现（try, confirm, cancel)三个步骤，不需要数据库特别支持，支持范围广，不会长久锁住资源（只会在每个阶段分别锁住一小会），每个RM可以单独执行，会引入中间状态（比如冻结状态），所以隔离性较好。TM等待所有try成功后就通知所有RM confirm， 否则就通知所有RM cancel。

#### Seata Saga

Break a distributed transaction into a sequence of local transactions, they have to be ordered, have:

*  a set of forward transactions for success case
*  a set of compensating transactions for rollback

##### UI

When tranaction fired, should return to user with generate response immediately (processing / will finish in 10 sec/...), 
Server can also use websocket to push notifications to UI when transactions finished. 
(should not let user wait until all finished unless it can finish less then 1 sec)

##### Interaction with other transactions
Saga complicated the business logic, suppose a order is committed, 
and a set of forward transactions is still in progress, order state is still pending,
at the same time, user cancelled the order, then it might can wait for the order transaction to finished before cancel the order.

##### Reliable transaction message publisher
1.  in a transaction: change business data in RDS,
2.	in the same transaction: write message to RDS queue table,
3.  another application can read the database queue table and load to message queue (how to identify uncomsumed message is a problem)
	or: read from queue table and mark them as deleted, then push them to mq?
	or: read the db transaction log and dump them to message queue.


Choreography: 
- message/event based;
- de-centralized logic;
- low coupling (purely reactive);
- difficult to visualize the workflow;

Orchestration:
- message/event based;
- centralized logic;
- high coupling;
- visualize workflow;


## DB Transaction Isolation level
Read Uncommitted
ReadCommitted
Reaptable Read
Serializable

## 集群选举方式
	ZooKeeper， 启动和Leader 宕机时需要选举Leader， leader负责
	Eureka：没有leader，所有结点平等提供服务，

## DDD (Domain Driven Design)
	DDD 是一种面向复杂软件系统分析和设计的面向对象建模方法论。一个系统的业务范围和在这个业务范围内进行的活动称为领域。 
	领域可以划分为很多子域（商品/订单/用户/库存/...）
	（与之对应的是数据驱动开发，自底向上：DB desgin-> entity ->DAO ->service->controller）

	架构层面：分子域和界限上下文
	编码层面：
		写操作：创建聚合根通过Factory完成；业务逻辑优先在聚合根边界内完成；聚合根中不合适放置的业务逻辑才考虑放到DomainService中；通过Repository持久化聚合根；通过Command 接收业务请求数据。
			ApplicationService: 
				没业务；
				与业务用例一一对应（API， RPC call, 其它调用）；
				事务性，每个方法是一个事物边界；
				领域模型的Facade， 不是整个软件系统的Facade，最终由Controller/RPC/Main 调用方法 使用；
				只接受原始数据类型参数（不能依赖领域模型中的对象，领域模型对他来说是黑盒，只管调用）

			Aggregate Root：
				就是领域对象（Order/Product/...)
				是主要的业务逻辑载体
				保证业务逻辑上的一致性（如改变订单商品数量时会自动update price);
				应该少引用框架，尽量只是用简单对象；
				聚合根之间引用通过ID完成，不引用整个对象；
				聚合根内部的变更必须通过聚合根完成；
				事务通常只更新一个聚合根，如果一个事务需要更新多个聚合根，考虑引用事件驱动或者消息机制;
				聚合根不应该使用基础设施；
				外界不应该持有聚合根内部的结构；
				尽量使用小聚合。

			Entity & ValueObject
				聚合根就是Entity， 聚合根也可以有子Entity；
				一般除了聚合根，尽量将其他对象建模为值对象；
				值对象是不可变的，确需改变就创建一个新值对象；
				同样的对象在不同上下文中可能是Entity， 也可以是VO；
			
			Repository:
				持久化（save = insert + update)聚合根；（也可用于查询，但是大量查询会导致Repo过于复杂）

			Factory：
				可以用来创建聚合根（简单的创建也可以不要Factory，直接在聚合根里创建create（xxx) 方法，不推荐直接使用构造函数, 因为构造函数可能有多个，不清晰）

			Domain Service：
				Application Service 必要时可以依赖Domain Service处理聚合根之外的逻辑；

			Command：
				接受ApplicationService （Controller 也是） 用于执行的外部命令

		读操作：
			Representation： 
				通常用来封装展现数据（Response）；
				可以使用聚合根转换（需要加载聚合根，或者同时加载聚合根子Entity， VO）；
				也可以直接去Repository查；
				或者使用： 在CQRS中写操作和读操作使用了不同的数据库 (CQRS(Command Query Responsibility Segregation)，即命令查询职责分离)

	Example Structure:

	├── order
	│   ├── OrderApplicationService.java
	│   ├── OrderController.java
	│   ├── OrderPaymentProxy.java
	│   ├── OrderPaymentService.java
	│   ├── OrderRepository.java
	│   ├── command
	│   │   ├── ChangeAddressDetailCommand.java
	│   │   ├── CreateOrderCommand.java
	│   │   ├── OrderItemCommand.java
	│   │   ├── PayOrderCommand.java
	│   │   └── UpdateProductCountCommand.java
	│   ├── exception
	│   │   ├── OrderCannotBeModifiedException.java
	│   │   ├── OrderNotFoundException.java
	│   │   ├── PaidPriceNotSameWithOrderPriceException.java
	│   │   └── ProductNotInOrderException.java
	│   ├── model
	│   │   ├── Order.java
	│   │   ├── OrderFactory.java
	│   │   ├── OrderId.java
	│   │   ├── OrderIdGenerator.java
	│   │   ├── OrderItem.java
	│   │   └── OrderStatus.java
	│   └── representation
	│       ├── OrderItemRepresentation.java
	│       ├── OrderRepresentation.java
	│       └── OrderRepresentationService.java

	ref： https://insights.thoughtworks.cn/backend-development-ddd/ 

## 微服务
	随着系统复杂度的不断提高（可能是因为业务越来越多越来越复杂）， 将单体应用拆分为微服务可以有效减少系统复杂度，提高性能和可用性等。
	DDD中的限界上下文可以用于指导微服务中的服务划分。

	Kubernetes：
		Helm： package manager for k8s
		Envoy：Service proxy （ingress to k8s）, Contour + Envoy (research: Istio)
		Prometheus：monitor metrics
		EFK：logging with elastic search + Fluentd + Kibana
		Jaeger：Tracing issues
		Istio: service mesh 

## dotnet

### .net 5
record class/struct
### .net 6
simplified development,

simple Console template, no need main templetes
Merge Program and Startup
Minimal APIs, even can define api without controller class, just map with func/action delegate, DI will inject the related service.
DateOnly and TimeOnly

performance，
hotreload


File-scoped namespace
Being able to use a namespace in a file, without having to wrap curly braces around it.

● Record structs
C# 9 introduced the record class feature. C# 10 goes further and you can now apply record structs. Handy if you want to make a struct immutable.

● Constant interpolated strings
Interpolated strings allow you to insert an object into a string without coming out of it. Now you can set an interpolated string as a constant.

● Extended property patterns
Handy if you are doing a condition on a nested property. You can now use a dot to get the nested property, rather than using curly braces.

● Global using directive
Being able to import namespaces that are commonly used into a single file, so they don't have to be imported in each individual file.

### delegate vs event
delegate is type refer to method (static or instance method), while event is a kind of multicast delegate, can be used in pub/sub area.
