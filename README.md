GIỚI THIỆU VỀ PROJECT
Đây là project xây dựng một phần mềm quản lý cho một cửa hàng smartphone. Hỗ trợ việc nhập, xuất, xóa, cập nhật dữ liệu một cách nhanh chóng và tiện lợi, hơn thế nữa, phần mềm còn có khả năng quản lý đơn hàng và quản lý nhân viên, cũng như khả năng phân tích hiệu suất và báo cáo thông kê dựa vào lượng sản phẩm tiêu thụ.

Thành viên:

- 21120053 - Lại Đức Dũng
- 21120063 - Hà Thanh Hải
- 21120064 - Lê Quốc Hân
- 21120197 - Cao Nguyễn Tuấn Anh

PHÂN CÔNG:

- Tuấn Anh
  - Sign in / Sign out (0.25)
  - Tạo file setup (0.25)
  - Làm rối mã nguồn, chống dịch ngược (0.25)
  - Backup / restore database (0.5)
  - Tự động thay đổi sắp xếp hợp lí các thành phần theo độ rộng màn hình (0.5)
- Quốc Hân

  - Dashboard (0.25):
  - Configuration (0.25):
  - Báo cáo thống kê (1.0)

- Đức Dũng
  - Kết nối rest API (1.0)
  - Thiết kế database
  - Viết logic API: login, signup, các hàm get, post cho mỗi trường data
- Thanh Hải.
  - Product Management (1.5)
  - Quản lí khách hàng (1.0)
  - Thiết kế body cho mainWindow
  - Order Management (1.5)

CÁC CHỨC NĂNG CHƯA THỂ THỰC HIỆN:

- Import dữ liệu gốc ban đầu (loại sản phẩm, danh sách các sản phẩm) từ tập tin Excel hoặc Access.
- Xem các sản phẩm và số lượng bán theo ngày đến ngày, theo tuần, theo tháng, theo năm (vẽ biểu đồ).
- Cho phép khi chạy chương trình lên thì mở lại màn hình cuối mà lần trước tắt.

CHỨC NĂNG CẦN XEM XÉT CỘNG ĐIỂM:

- Tạo báo cáo thống kê.
  -> Chúng em gặp khó khăn trong việc xử lí dữ liệu cũng như đồng bộ dữ liệu khi gọi API, hơn thế nữa việc tạo lập biểu đồ thống kê cũng là một trở ngại rất lớn khi phải thực hiện song song với việc binding dữ liệu.
- Đăng kí / Đăng nhập.
  -> Chúng em dành nhiều thời gian trong việc đồng bộ dữ liệu khi phải áp dụng API để tương tác với database.
- Thiết kế tổng quan cho phần mềm.
  -> Chúng em đã dành phần lớn thời gian cho việc đồng bộ về mặt thiết kế lẫn cấu hình, với mục đích mang đến trải nghiệm tốt nhất cho người dùng.

MÔI TRƯỜNG THỰC THI:

- VS Code
- Visual Studio

CÁCH SỬ DỤNG:

- Trước khi thực thi ứng dụng, người dùng cần thực thi server:
  - Bước 1: Tải và cài đặt NodeJs, VS Code.
  - Bước 2: Vào VS code, mở một terminal mới, thực thi lần lượt các câu lệnh sau:
    - npm i: cài đặt các gói cần thiết.
    - npm start: khởi chạy server.
- Sau khi thực thi server, người dùng tiến hành cài đặt ứng dụng và sử dụng tùy vào nhu cầu.

TRANG WEB BAO GỒM CÁC MÀN HÌNH CHÍNH:

- Màn hình đăng kí và đăng nhập.
- Màn hình dashboard: hiển thị số lượng sản phẩm, tổng số đơn đặt hàng và tổng doanh thu, 5 đơn hàng có số lượng cao nhất.
- Màn hình product: hiển thị thông tin chi tiết của sản phẩm, kèm theo đó là chức năng tìm kiếm, lọc sản phẩm theo năm sản xuất, sắp xếp sản phẩm theo theo từng tiêu chí, thểm, sửa, xóa sản phẩm.
- Màn hình user: hiển thị thông tin người dùng trên nền tảng, kèm theo đó là chức năng tìm kiếm, sắp xếp theo từng tiêu chí, thêm, sửa, xóa.
- Màn hình order: hiển thị thông tin đơn hàng, kèm theo đó là chức năng tìm kiếm đơn hàng, sắp xếp theo từng tiêu chí, lọc đơn hàng theo thời điểm đặt hàng, thêm, sửa, xóa đơn hàng.
- Màn hình analysis: hiển thị số lượng sản phẩm, tổng số đơn đặt hàng và tổng doanh thu, thống kê doanh thu theo ngày và năm.

CHỨC NĂNG ĐÃ HOÀN THÀNH
Chức năng cơ bản:

Sign in / Sign out (0.25): 100%
Dashboard (0.25): 100%
Product Management (1.5): 100%
Order Management (1.5): 100%
Báo cáo thống kê (1.0): 50%
Configuration (0.25): 50%  
Tạo file setup (0.25): 100%

Chức năng nâng cao:

Sử dụng giao diện lấy từ pinterest (0.5): 100%
Quản lí khách hàng (1.0): 100%
Tự động thay đổi sắp xếp hợp lí các thành phần theo độ rộng màn hình (0.5): 100%
Backup / restore database (0.5): 100%
Tổ chức theo mô hình 3 lớp (1.0): 100%
Kết nối rest API (1.0): 100%

TỰ ĐÁNH GIÁ:

- Lại Đức Dũng: 25%
- Hà Thanh Hải : 25%
- Lê Quốc Hân : 25%
- Cao Nguyễn Tuấn Anh : 25%
