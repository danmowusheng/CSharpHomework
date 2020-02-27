#include <iostream>
using namespace std;

class BaseClass {
public:
	virtual ~BaseClass() {
		cout << "调用基类析构函数" << endl;
	}
	void fn1() {};
};

class DerivedClass :public BaseClass {
public:
	~DerivedClass(){
		cout << "调用派生类析构函数" << endl;
	}
	void fn1() {};
};

int main()
{
	BaseClass* sp = new DerivedClass;          //动态生成对象
	delete sp;                         //利用基类指针的虚析构函数，派生类的析构函数被调用，内存空间被正确释放了
	return 0;
}

