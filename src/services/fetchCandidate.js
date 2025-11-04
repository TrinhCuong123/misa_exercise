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
  return JSON.parse(JSON.stringify(candidateData))
}

export { pushDataCandidate }
