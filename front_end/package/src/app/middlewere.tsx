// import { NextResponse } from 'next/server';
// import type { NextRequest } from 'next/server';

// export function middleware(request: NextRequest) {
//   // Lấy token từ cookie
//   const token = request.cookies.get('auth_token');

//   // Kiểm tra nếu không có token
//   if (!token) {
//     return NextResponse.redirect(new URL('/authentication/auth/AuthLogin', request.url));
//   }

//   // Cho phép truy cập nếu có token
//   return NextResponse.next();
// }

// // Áp dụng middleware cho tất cả các route trong Dashboard
// export const config = {
//   matcher: ['/dashboard/:path*'], // Tất cả các route có tiền tố "/dashboard/"
// };
