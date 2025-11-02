import '@/assets/css/commons.css'
import '@/assets/css/iconLink.css'
import '@/assets/css/icon.css'
import '@/assets/css/variables.css'
import '@/assets/css/reset.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config'
import Aura from '@primeuix/themes/aura'

const app = createApp(App)
app.use(PrimeVue, {
  theme: {
    preset: Aura,
  },
  locale: {
    selectionMessage: '{0} đã được chọn',
    emptySelectionMessage: 'Không có lựa chọn nào',
    emptySearchMessage: 'Không tìm thấy kết quả nào',
    searchMessage: '{0} kết quả được tìm thấy',
    accept: 'Đồng ý',
    reject: 'Hủy bỏ',
    firstDayOfWeek: 1,
    dayNames: ['Chủ Nhật', 'Thứ Hai', 'Thứ Ba', 'Thứ Tư', 'Thứ Năm', 'Thứ Sáu', 'Thứ Bảy'],
    dayNamesShort: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
    dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
    monthNames: [
      'Tháng 1',
      'Tháng 2',
      'Tháng 3',
      'Tháng 4',
      'Tháng 5',
      'Tháng 6',
      'Tháng 7',
      'Tháng 8',
      'Tháng 9',
      'Tháng 10',
      'Tháng 11',
      'Tháng 12',
    ],
    monthNamesShort: [
      'Th1',
      'Th2',
      'Th3',
      'Th4',
      'Th5',
      'Th6',
      'Th7',
      'Th8',
      'Th9',
      'Th10',
      'Th11',
      'Th12',
    ],
    today: 'Hôm nay',
    clear: 'Xóa',
    fileSizeTypes: ['KB', 'MB', 'GB', 'TB'],
  },
})
app.use(router)

app.mount('#app')
