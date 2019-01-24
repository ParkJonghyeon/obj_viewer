# obj_viewer
A viewer that reads the .obj file and displays the result as a vertex or polygon. Using OpenTK and winform.

---

충남대학교 학부 4학년 인턴십 중 제작한 프로그램  
OpenTK 라이브러리와 C#의 Winform을 사용한 .obj 파일 뷰어  
  
* .obj 파일을 읽어 화면상에 vertex 구조체를 렌더링  
* 메뉴 바에서 옵션을 통해 폴리곤 상태로 변환 가능 (텍스쳐 미구현)  
* w,a,s,d로 시점을 상하좌우로 조정 가능하며 q,e로 모델 회전 가능 (메뉴에서 시점 프리셋 사용가능)  
* 공간상의 두 점을 이어서 선을 그을 수 있으나 정확히 모델 위에 위치한 점을 찍는 것은 아님  
  
### Problem
* 최소 8gb 메모리에서 동작하는 문제  
* 광원 적용 문제로 흰색 모델이 회색으로 렌더링
* 공간상에 점을 찍는 것이 아닌 모델 위에 점을 찍어야함
