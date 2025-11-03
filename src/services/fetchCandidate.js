//lay data tu Json luu vao localStorage
import candidateData from '@/assets/data/candidate.json'

function pushDataCandidate() {
  // Kiểm tra nếu localStorage đã có dữ liệu
  const existingData = localStorage.getItem('candidateData')
  if (existingData) {
    const data = JSON.parse(localStorage.getItem('candidateData'))
    return data
  }

  localStorage.setItem('candidateData', JSON.stringify(candidateData))
  return JSON.stringify(candidateData)
  // Nếu chưa có dữ liệu, lấy từ candidate.json và lưu vào localStorage
  // fetch('@/assets/data/candidate.json')
  //   .then((response) => response?.json()) // chuyển body -> object
  //   .then((data) => {
  //     localStorage.setItem('candidateData', JSON.stringify(data))
  //     return data
  //   })
  //   .catch((error) => console.error('Lỗi khi tải JSON:', error))
}

export { pushDataCandidate }
