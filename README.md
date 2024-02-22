# BankPractice/이주환
 
# Spartan Bank 만들기

이번 과제는 저번에 만들지 못한 은행 만들기를 만들어 보았습니다.

이번 과제의 초점은 저번 UI특강과 이번 챌린지 세션에서 배운 UI Manager를 사용해 최대한 깔끔하게 UI를 관리하고 또한 Hierachy창에 필요없는 오브젝트들은 비우고 최대한 동적생성을 하는 쪽으로 구현하고자 노력했다.

대신 UI Manager와 Json을 통한 데이터 저장이 주가 되다보니 다른 불필요한 요구사항들은 제처두고 진행하였다.

# 궁금한 점

## 싱글톤의 사용
진행하면서 헷갈렸던 점은 일단 싱글톤의 사용이다.
지금은 입금, 출금, 송금만 가능한 간단한 예제임에도 불구하고 4개의 싱글톤을 사용하고있다.

![image](https://github.com/leejh0469/BankPractice/assets/43924035/eea5dab9-92d0-470b-b42a-984736cab2bc)

UI Manager는 UI관리를 위해 필요하고, UserDAO는 유저 관련 데이터 엑세스 관련 클래스, DataManager는 가져온 유저데이터와 관련된 처리를 해주는 클래스, MyData는 로그인 시 자신의 회원정보를 저장할 공간으로,
내 기준에는 모두 필요하다 생각하고 만들고 보니 간단한 기능 구현에 벌써 4개의 싱글톤이 생겼다.

싱글톤이 많으면 투명성을 해치고 또 뭐가 나쁘고 이런 말을 본 적이 있어 최대한 싱글톤을 배제하는 방식으로 구현을 좀 더 진행해야 할 것 같다. DAO는 지금은 처음 필요한 데이터를 다 긁어와 DataManager에 저장되기 때문에 사용할 필요가 없어보이지만, 나중에 실제 서버에서 데이터를 가져와야 한다면 꽤나 자주 불릴 클래스같아 싱글톤으로 만들어놓았다. 다만 UserData 에 대한 DAO뿐 아니라 다른 DAO까지 여러개 생기면 그걸 모두 싱글톤으로 관리해야 하는 건가 하는 의문이 들기는 한다.

## UI 관리
다음으로는 UI Manager를 사용하면서 이렇게 기능이 조금씩 다른 UI에 대한 Prefab과 스크립트를 모두 만들어 관리하다 보니 그 짧은 기능구현에 어느새 거의 10개가 되는 Prefab과 스크립트가 생성되었다.

![image](https://github.com/leejh0469/BankPractice/assets/43924035/5aa3faf3-4031-4ba6-8909-e36154e00767)

UIPopup과 같이 출력해줄 문구만 다르다면 언제든 재사용이 가능하겠지만, Login, Signup, Deposit 기타 등등 조금 다른데서 재사용하기 어려운것들을 이렇게 관리하는게 물론 좋겠지만 너무 많이 생성된 스크립트를 보면 좀 더 좋은 방법이 없나 생각하게 된다.
당장은 좋은 생각이 나는게 없기 때문에 넘어가기로 한다.

그리고 원래는 Firebase를 사용해 데이터를 저장하고 관리할 생각을 했는데 조금 찾아보니 Unity 프로젝트를 추가하려면 빌드 세팅을 안드로이드나 Ios로 바꿔야 된다는 것 같아 빠르게 포기했다.
대신 나중에 기회가 된다면 프레임워크를 사용한 간단한 웹서버는 구현해본 바 있기 때문에 나중에 랭킹이나 실제 로그인 회원가입은 구현해보면 좋을 것 같다.
