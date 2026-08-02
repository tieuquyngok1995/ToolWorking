# 🚀 Work Buddy - Desktop Application

**Work Buddy** là một ứng dụng desktop hỗ trợ tối ưu hóa và tự động hóa các tác vụ xử lý tệp, cơ sở dữ liệu và định dạng dữ liệu trong công việc hàng ngày của lập trình viên và quản trị viên hệ thống.

---

## 🛠️ Công nghệ & Thư viện sử dụng (Tech Stack)

* **Framework**: .NET / C# (WinForms)
* **Giao diện (UI Framework)**: [SunnyUI](https://gitee.com/yhuse/SunnyUI) - Thư viện WinForms UI mã nguồn mở hiện đại, hỗ trợ nhiều theme và giao diện phẳng đẹp mắt.

---

## 📌 1. Giao diện & Cấu trúc (UI Layout)

Ứng dụng được thiết kế theo cấu trúc hiện đại, tiện lợi và dễ thao tác:

* **Header**:
  * Hiển thị thông tin tên ứng dụng, logo và thông báo trạng thái hoạt động.
  * Góc phải tích hợp **Button Setting ⚙️** giúp truy cập nhanh vào phần cài đặt hệ thống.
* **Menu Bar (Bên trái)**:
  * Thanh điều hướng dọc chứa danh sách các chức năng chính.
  * Khi chọn từng tab menu, hệ thống sẽ di chuyển hoặc mở các **Child Forms** tương ứng ở không gian làm việc chính (Main Content Area).

---

## 🔥 2. Các Chức năng chính (Features)

Work Buddy cung cấp tập hợp các công cụ mạnh mẽ hỗ trợ quản lý và xử lý dữ liệu:

### 📁 Quản lý Tệp & Thư mục (File & Directory Management)
1. **Tìm kiếm tệp trong thư mục**:
   * Tìm kiếm nhanh các tệp tin theo tên, phần mở rộng (extension) hoặc từ khóa nội dung trong thư mục được chỉ định.
   * Hỗ trợ bộ lọc theo ngày tạo, kích thước file.
2. **Tạo & Di chuyển tệp/thư mục**:
   * Tạo nhanh cấu trúc thư mục hoặc các tệp tin mới.
   * Di chuyển, sao chép hàng loạt tệp tin đến thư mục mục tiêu một cách an toàn.
3. **Tạo tệp theo định dạng**:
   * Cho phép tạo mới các tệp tin với nhiều định dạng tùy chuẩn (ví dụ: `.txt`, `.csv`, `.log`, `.md`, `.xml`,...).

### 🗄️ Cơ sở dữ liệu & Script Execution (Database & Scripts)
4. **Tạo Database theo Cài đặt**:
   * Tự động khởi tạo database (MySQL, PostgreSQL, SQLite, SQL Server...) dựa trên thông số cấu hình trong phần **Setting**.
5. **Chạy Script trong thư mục**:
   * Tự động duyệt và thực thi hàng loạt tệp script (`.sql`, `.bat`, `.sh`, `.py`,...) nằm trong một thư mục được chọn theo thứ tự.

### 📝 Sinh & Xử lý Dữ liệu (Data Generation & Formatting)
6. **Tạo nội dung file JSON theo Setting**:
   * Sinh tự động dữ liệu JSON (Mock data / Config data) dựa trên cấu hình template và quy tắc đã thiết lập trước.
7. **Format file SQL theo Setting**:
   * Tự động chuẩn hóa, định dạng (beautify/indent) các câu lệnh SQL trong tệp theo chuẩn code convention đã cài đặt.

---

## ⚙️ 3. Cài đặt Hệ thống (Settings)

Trang **Setting** (mở từ nút bấm trên Header) cho phép tùy chỉnh các cấu hình chung:
* **Database Config**: Cấu hình thông số kết nối cơ sở dữ liệu (Host, Port, Username, Password, Database Name, Driver).
* **JSON Generator Rules**: Cấu hình kiểu dữ liệu mặc định, cấu trúc template sinh JSON.
* **SQL Formatter Rules**: Tùy chỉnh chuẩn định dạng SQL (viết hoa từ khóa, số ký tự lề, dấu phẩy đầu/cuối dòng,...).
* **General Settings**: Tùy chỉnh thư mục mặc định, giao diện (Light/Dark Mode), ngôn ngữ ứng dụng.

---

## 🛠️ 4. Hướng dẫn Cài đặt & Sử dụng (Getting Started)

### Yêu cầu hệ thống
* Hệ điều hành: Windows 10/11.
* Môi trường runtime thích hợp.

### Các bước cài đặt
1. Tải bản phát hành mới nhất từ thư mục `Releases` hoặc build từ mã nguồn.
2. Khởi chạy tập tin thực thi (`WorkBuddy.exe` hoặc `WorkBuddy.dmg`).
3. Truy cập nút **Setting ⚙️** trên Header để thiết lập cấu hình Database và các tham số mặc định trước khi sử dụng.

---

## 📝 Giấy phép (License)
Dự án được phát hành dưới mã nguồn mở / bản quyền nội bộ.